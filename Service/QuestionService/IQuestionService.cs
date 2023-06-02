using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKBase.Models;
using MKBase.Dto.Question;

namespace MKBase.Service.QuestionService
{
    public interface IQuestionService
    {
        ServiceResponse<GetQuestionDto> CreateQuestion(AddQuestionDto request);
        ServiceResponse<GetQuestionDto> GetQuestionById(QuestionSurveyIdDto request);
        ServiceResponse<List<GetQuestionDto>> GetAllQuestions(int surveyId);
        ServiceResponse<GetQuestionDto> EditQuestionContent(EditQuestionDto request);
        ServiceResponse<string> DeleteQuestionById(int id);
    }
}