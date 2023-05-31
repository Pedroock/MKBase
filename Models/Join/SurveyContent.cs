using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKBase.Models.Join
{
    public class SurveyContent
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int ContentId { get; set; }
        public int Type { get; set; }
    }
}