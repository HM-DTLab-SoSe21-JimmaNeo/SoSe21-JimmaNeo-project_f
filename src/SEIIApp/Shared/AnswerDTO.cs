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
        [Required]
        public string Answer { get; set; }

        public bool IsCorret { get; set; }
    }
}
