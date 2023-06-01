using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKBase.Dto.Survey
{
    public class GetSurveyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Intro { get; set; } = string.Empty;
        public List<int>? QuestionsId { get; set; }
    }
}