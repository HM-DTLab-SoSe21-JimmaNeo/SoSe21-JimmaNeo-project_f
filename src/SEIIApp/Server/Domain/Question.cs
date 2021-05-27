using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; } 

        public string QuestionText { get; set; }

        public List<Answer> Answers { get; set; }

        public string Explanation { get; set; }
    }
}
