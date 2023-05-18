using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKBase.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Position { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Options { get; set; } = string.Empty;
        public Survey? Survey { get; set; }
        public int SurveyId { get; set; }
    }
}