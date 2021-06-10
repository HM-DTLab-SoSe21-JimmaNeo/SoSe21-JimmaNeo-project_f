using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
  public class CompletedTestDTO
  {
    public int CtId { get; set; }

    public TestBaseDTO SolvedTest { get; set; }

    public UserDTO Student { get; set; }

    public int ReachedPoints { get; set; }

    public int MaxPoints { get; set; }

  }
}
