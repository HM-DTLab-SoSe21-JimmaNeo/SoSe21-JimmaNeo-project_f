using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class QuestionDTO
    {
        [Required]
        [StringLength(250)]
        public string Question { get; set; }

        public List<AnswerDTO> Answers { get; set; }

        [StringLength(250)]
        public string Explanation { get; set; }
        
    }
}
