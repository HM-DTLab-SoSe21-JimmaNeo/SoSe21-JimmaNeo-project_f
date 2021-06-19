using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SEIIApp.Shared
{
    public class VideoContentDTO
    {
        [Required(ErrorMessage = "Video Url-Path is required")]
        [StringLength(100, MinimumLength = 1)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
