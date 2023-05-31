using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKBase.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Intro { get; set; } = string.Empty;
        public List<Question>? Questions { get; set; }
        public User? User { get; set; }
    }
}