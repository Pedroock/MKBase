using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MKBase.Service.QuestionService;
using Microsoft.AspNetCore.Authorization;

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
        
    }
}