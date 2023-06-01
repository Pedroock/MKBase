using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKBase.Models;
using MKBase.Dto.Survey;

namespace MKBase.Service.SurveyService
{
    public interface ISurveyService
    {
        ServiceResponse<GetSurveyDto> CreateSurvey(AddSurveyDto request);
        ServiceResponse<GetSurveyDto> GetSurveyById(int id);
        ServiceResponse<List<GetSurveyDto>> GetAllSurveys();
        ServiceResponse<GetSurveyDto> EditSurveyInfo(EditSurveyDto request);
        ServiceResponse<string> DeleteSurveyById(int id);
    }
}