using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Server.Domain
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set;  }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

    }
}
