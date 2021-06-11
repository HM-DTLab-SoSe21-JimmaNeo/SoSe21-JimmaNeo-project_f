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
    [StringLength(500, MinimumLength = 1)]
    public string QuestionText { get; set; }

    public List<AnswerDTO> Answers { get; set; }

    [StringLength(500)]
    public string Explanation { get; set; }

    public List<PictureContentDTO> Pictures { get; set; }

  }
}
