using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKBase.Dto.Question
{
    public class EditQuestionDto
    {
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Options { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}