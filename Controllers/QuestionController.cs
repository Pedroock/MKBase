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
    [Route("api/questions")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpPost()]
        public ActionResult<ServiceResponse<GetQuestionDto>> CreateQuestion(AddQuestionDto request)
        {
            ServiceResponse<GetQuestionDto> response = _questionService.CreateQuestion(request);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ServiceResponse<GetQuestionDto>> GetQuestionById(int id)
        {
            ServiceResponse<GetQuestionDto> response = _questionService.GetQuestionById(id);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet()]
        public ActionResult<ServiceResponse<List<GetQuestionDto>>> GetAllQuestions(int surveyId)
        {
            ServiceResponse<List<GetQuestionDto>> response = _questionService.GetAllQuestions(surveyId);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut()]
        public ActionResult<ServiceResponse<GetQuestionDto>> EditQuestionContent(EditQuestionDto request)
        {
            ServiceResponse<GetQuestionDto> response = _questionService.EditQuestionContent(request);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ServiceResponse<string>> DeleeteQuestionById(int id)
        {
            ServiceResponse<string> response = _questionService.DeleteQuestionById(id);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}