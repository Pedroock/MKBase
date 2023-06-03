using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MKBase.Data;
using MKBase.Dto.Survey;
using MKBase.Models;
using MKBase.Service.ContextService;

namespace MKBase.Service.SurveyService
{
    public class SurveyService : ISurveyService
    {
        private readonly IContextService _contextService;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SurveyService(IContextService contextService, DataContext context, IMapper mapper)
        {
            _contextService = contextService;
            _context = context;
            _mapper = mapper;
        }
        // Needed
        private List<int> GetSurveyQuestionIds(int surveyId)
        {
            Survey survey = _context.Surveys.Include(s => s.Questions).FirstOrDefault(s => s.Id == surveyId)!;
            if(survey.Questions is null)
            {
                return new List<int>();
            }
            List<int> questionIds = new List<int>();
            foreach(Question question in survey.Questions)
            {
                questionIds.Add(question.Id);
            }
            return questionIds;
        }
        // Surveys
        public ServiceResponse<GetSurveyDto> CreateSurvey(AddSurveyDto request)
        {
            ServiceResponse<GetSurveyDto> response = new ServiceResponse<GetSurveyDto>();
            try
            {
                User user = _contextService.GetCurrentUser();
                Survey survey = _mapper.Map<Survey>(request);
                survey.User = user;
                _context.Surveys.Add(survey);
                _context.SaveChanges();
                response.Message = "Created the survey";
                response.Data = _mapper.Map<GetSurveyDto>(survey);
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            
        }
        public ServiceResponse<GetSurveyDto> GetSurveyById(int id)
        {
            ServiceResponse<GetSurveyDto> response = new ServiceResponse<GetSurveyDto>();
            try
            {
                Survey survey = _context.Surveys.Include(s => s.User).FirstOrDefault(s => s.Id == id)!;
                if(survey is null)
                {
                    response.Success = false;
                    response.Message = "There is no survey with this id";
                    return response;
                }
                if(survey.User != _contextService.GetCurrentUser())
                {
                    response.Success = false;
                    response.Message = "You have no surveys with this id";
                    return response;
                }
                GetSurveyDto surveyDto = _mapper.Map<GetSurveyDto>(survey);
                surveyDto.QuestionsId = (GetSurveyQuestionIds(survey.Id));
                response.Data = surveyDto;
                response.Message = "Thats the survey";
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
        }
        public ServiceResponse<List<GetSurveyDto>> GetAllSurveys()
        {
            ServiceResponse<List<GetSurveyDto>> response = new ServiceResponse<List<GetSurveyDto>>();
            try
            {
                List<GetSurveyDto> surveyDtos = new List<GetSurveyDto>();
                List<Survey> surveys = _context.Surveys
                    .Where(s => s.User == _contextService.GetCurrentUser())
                    .ToList();
                foreach(Survey survey in surveys)
                {
                    GetSurveyDto surveyDto = _mapper.Map<GetSurveyDto>(survey);
                    surveyDto.QuestionsId = GetSurveyQuestionIds(survey.Id);
                    surveyDtos.Add(surveyDto);
                }
                response.Data = surveyDtos;
                response.Message = "These are the surveys";
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            } 
        }
        public ServiceResponse<GetSurveyDto> EditSurveyInfo(EditSurveyDto request)
        {
            ServiceResponse<GetSurveyDto> response = new ServiceResponse<GetSurveyDto>();
            try
            {
                Survey survey =_context.Surveys.Include(s => s.User).FirstOrDefault(s => s.Id == request.Id)!;
                if(survey is null)
                {
                    response.Success = false;
                    response.Message = "No survey with this id";
                    return response;
                }
                survey.Intro = request.Intro;
                survey.Name = request.Name;
                _context.SaveChanges();
                response.Data = _mapper.Map<GetSurveyDto>(survey);
                response.Message = "Thats the survey";
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
        }
        public ServiceResponse<string> DeleteSurveyById(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                Survey survey = _context.Surveys.Include(s => s.User).FirstOrDefault(s => s.Id == id)!;
                if(survey is null)
                {
                    response.Success = false;
                    response.Message = "No survey with this id";
                    return response;
                }
                if(survey.User != _contextService.GetCurrentUser())
                {
                    response.Success = false;
                    response.Message = "You have no surveys with this id";
                    return response;
                }
                _context.Surveys.Remove(survey);
                _context.SaveChanges();
                response.Data = $"Survey with id {id}";
                response.Message = "The survey has been deleted";
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
        }
    }
}