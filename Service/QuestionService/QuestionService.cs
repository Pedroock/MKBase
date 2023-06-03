using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MKBase.Data;
using MKBase.Dto.Question;
using MKBase.Models;
using MKBase.Service.ContextService;

namespace MKBase.Service.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly DataContext _context;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;
        public QuestionService(DataContext context, IContextService contextService, IMapper mapper)
        {
            _context = context;
            _contextService = contextService;
            _mapper = mapper;
        }
        // Needed methods
        private GetQuestionDto MapQuestionDto(Question question)
        {
            GetQuestionDto questionDto = _mapper.Map<GetQuestionDto>(question);
            questionDto.SurveyId = question.Survey!.Id;
            questionDto.SurveyName = question.Survey!.Name;
            return questionDto;
        }

        // Interface methods
        public ServiceResponse<GetQuestionDto> CreateQuestion(AddQuestionDto request)
        {
            ServiceResponse<GetQuestionDto> response = new ServiceResponse<GetQuestionDto>();
            try
            {
                Survey survey = _context.Surveys
                    .Include(s => s.User).FirstOrDefault(s => s.Id == request.SurveyId)!;
                if(survey is null)
                {
                    response.Success = false;
                    response.Message = "No survey with this id";
                    return response;
                }
                if(_contextService.SurveyIsOwnedByCurrentUser(survey.Id) == false)
                {
                    response.Success = false;
                    response.Message = "You have no access to this survey";
                    return response;
                }
                Question question = _mapper.Map<Question>(request);
                question.Survey = survey;
                _context.Questions.Add(question);
                _context.SaveChanges();
                response.Message = "You have created the question";
                response.Data = MapQuestionDto(question);
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
        }

        public ServiceResponse<GetQuestionDto> GetQuestionById(QuestionSurveyIdDto request)
        {
            ServiceResponse<GetQuestionDto> response = new ServiceResponse<GetQuestionDto>();
            try
            {
                Question question = _context.Questions
                    .Include(q => q.Survey).FirstOrDefault(q => q.Id == request.QuestionId)!;
                if(question is null)
                {
                    response.Success = false;
                    response.Message = "There is no question with this id";
                    return response;
                }
                if(_contextService.SurveyIsOwnedByCurrentUser(question.Survey!.Id) == false)
                {
                    response.Success = false;
                    response.Message = "You have no access to this question";
                    return response;
                }
                response.Message = "This is the question";
                response.Data = MapQuestionDto(question);
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
        }

        public ServiceResponse<List<GetQuestionDto>> GetAllQuestions(int surveyId)
        {
            ServiceResponse<List<GetQuestionDto>> response = new ServiceResponse<List<GetQuestionDto>>();
            try
            {
                Survey survey = _context.Surveys.FirstOrDefault(s => s.Id == surveyId)!;
                if(survey is null)
                {
                    response.Success = false;
                    response.Message = "There is no survey with this id";
                    return response;
                }
                if(_contextService.SurveyIsOwnedByCurrentUser(surveyId) == false)
                {
                    response.Success = false;
                    response.Message = "You have no access to this survey";
                    return response;
                }
                List<Question> questions = _context.Questions
                    .Include(q => q.Survey).Where(q => q.Survey == survey)!.ToList();
                List<GetQuestionDto> questionDtoList = new List<GetQuestionDto>();
                foreach(Question question in questions)
                {
                    questionDtoList.Add(MapQuestionDto(question));
                }
                response.Message = "These are the questions";
                response.Data = questionDtoList;
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
        }

        public ServiceResponse<GetQuestionDto> EditQuestionContent(EditQuestionDto request)
        {
            ServiceResponse<GetQuestionDto> response = new ServiceResponse<GetQuestionDto>();
            try
            {
                Question question = _context.Questions
                    .Include(q => q.Survey).FirstOrDefault(q => q.Id == request.QuestionId)!;
                if(question is null)
                {
                    response.Success = false;
                    response.Message = "There is no question with this id";
                    return response;
                }
                if(_contextService.SurveyIsOwnedByCurrentUser(request.SurveyId) == false)
                {
                    response.Success = false;
                    response.Message = "You have no access to this question";
                    return response;
                }
                question.Title = request.Title;
                question.Type = request.Type;
                question.Content = request.Content;
                question.Options = request.Options;
                _context.SaveChanges();
                response.Message = "You have successfully edited the question";
                response.Data = MapQuestionDto(question);
                return response;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
        }

        public ServiceResponse<string> DeleteQuestionById(QuestionSurveyIdDto request)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                Question question = _context.Questions
                    .Include(q => q.Survey).FirstOrDefault(q => q.Id == request.QuestionId)!;
                if(question is null)
                {
                    response.Success = false;
                    response.Message = "There is no question with this id";
                    return response;
                }
                if(_contextService.SurveyIsOwnedByCurrentUser(question.Survey!.Id) == false)
                {
                    response.Success = false;
                    response.Message = "You have no access to this question";
                    return response;
                }
                response.Data = $"questionId {question.Id}";
                _context.Questions.Remove(question);
                _context.SaveChanges();
                response.Message = "You have deleted the question";
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