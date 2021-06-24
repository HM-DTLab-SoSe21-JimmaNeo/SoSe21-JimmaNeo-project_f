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

        [Required(ErrorMessage = "PNG Picture is required")]
        public string Path { get; set; }

        public string Description { get; set; }
    }
}
