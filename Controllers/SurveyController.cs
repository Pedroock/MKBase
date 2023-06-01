using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MKBase.Models;
using MKBase.Dto.Survey;
using MKBase.Service.SurveyService;
using Microsoft.AspNetCore.Authorization;

namespace MKBase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [HttpPost("Create Survey")]
        public ActionResult<ServiceResponse<GetSurveyDto>> CreateSurvey(AddSurveyDto request)
        {
            ServiceResponse<GetSurveyDto> response = _surveyService.CreateSurvey(request)!;
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("Get Survey By Id")]
        public ActionResult<ServiceResponse<GetSurveyDto>> GetSurveyById(int id)
        {
            ServiceResponse<GetSurveyDto> response = _surveyService.GetSurveyById(id)!;
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("Get All Surveys")]
        public ActionResult<ServiceResponse<List<GetSurveyDto>>> GetAllSurveys()
        {
            ServiceResponse<List<GetSurveyDto>> response = _surveyService.GetAllSurveys()!;
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("Edit Survey Info")]
        public ActionResult<ServiceResponse<GetSurveyDto>> EditSurveyInfo(EditSurveyDto request)
        {
            ServiceResponse<GetSurveyDto> response = _surveyService.EditSurveyInfo(request)!;
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("Delete Survey By Id")]
        public ActionResult<ServiceResponse<string>> DeleteSurveyById(int id)
        {
            ServiceResponse<string> response = _surveyService.DeleteSurveyById(id)!;
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}