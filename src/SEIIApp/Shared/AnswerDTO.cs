using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class AnswerDTO
    {
        [Required(ErrorMessage = "Answer is required")]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsClicked { get; set; }
    }
}
