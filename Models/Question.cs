using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MKBase.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Unicode(false)]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public int Position { get; set; }
        [Unicode(false)]
        [MaxLength(500)]
        public string Options { get; set; } = string.Empty;
        public List<Answer>? Answers { get; set; }
    }
}