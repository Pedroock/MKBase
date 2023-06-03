using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MKBase.Service.QuestionService;
using Microsoft.AspNetCore.Authorization;
using MKBase.Models;
using MKBase.Dto.Question;

namespace MKBase.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionService : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionService(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpPost("Creaete Question")]
        public ActionResult<ServiceResponse<GetQuestionDto>> CreateQuestion(AddQuestionDto request)
        {
            ServiceResponse<GetQuestionDto> response = _questionService.CreateQuestion(request);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Get Question By Id")]
        public ActionResult<ServiceResponse<GetQuestionDto>> GetQuestionById(QuestionSurveyIdDto request)
        {
            ServiceResponse<GetQuestionDto> response = _questionService.GetQuestionById(request);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("Get All Questions")]
        public ActionResult<ServiceResponse<List<GetQuestionDto>>> GetAllQuestions(int surveyId)
        {
            ServiceResponse<List<GetQuestionDto>> response = _questionService.GetAllQuestions(surveyId);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("Edit Question Content")]
        public ActionResult<ServiceResponse<GetQuestionDto>> EditQuestionContent(EditQuestionDto request)
        {
            ServiceResponse<GetQuestionDto> response = _questionService.EditQuestionContent(request);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("Delete Question By Id")]
        public ActionResult<ServiceResponse<string>> DeleeteQuestionById(QuestionSurveyIdDto request)
        {
            ServiceResponse<string> response = _questionService.DeleteQuestionById(request);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}