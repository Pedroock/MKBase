using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MKBase.Dto.User;
using MKBase.Dto.Survey;
using MKBase.Dto.Question;
using MKBase.Models;

namespace MKBase
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<x, y>();
            CreateMap<User, GetUserDto>();
            CreateMap<AddSurveyDto, Survey>();
            CreateMap<Survey, GetSurveyDto>();
            CreateMap<AddQuestionDto, Question>();
            CreateMap<Question, GetQuestionDto>();
        }
    }
}