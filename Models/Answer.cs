using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MKBase.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        [Unicode(false)]
        [MaxLength(500)]
        public string Value { get; set; } = string.Empty;
    }
}