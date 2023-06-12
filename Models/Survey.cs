using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MKBase.Models
{
    public class Survey
    {
        public int Id { get; set; }
        [Unicode(false)]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Unicode(false)]
        [MaxLength(300)]
        public string Intro { get; set; } = string.Empty;
        public List<Question>? Questions { get; set; }
        public User? User { get; set; }
    }
}