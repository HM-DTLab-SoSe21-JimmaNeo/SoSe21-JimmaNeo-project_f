using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
  public class CompletedTestDTO
  {
    public int CtId { get; set; }
    [Required]
    public TestDTO SolvedTest { get; set; }

    public UserDTO Student { get; set; }

    public int ReachedPoints { get; set; }

    public int MaxPoints { get; set; }

  }
}
