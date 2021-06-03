using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class PictureContentDTO
    {
        [Required]
        public string Path;

        [StringLength(250)]
        public string Description;
    }
}
