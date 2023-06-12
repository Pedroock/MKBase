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
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Unicode(false)]
        [MaxLength(3)]
        public string Type { get; set; } = string.Empty;
        [Unicode(false)]
        public string Content { get; set; } = string.Empty;
        [Unicode(false)]
        public string Options { get; set; } = string.Empty;
        public int Position { get; set; }
        public Survey? Survey { get; set; }
    }
}