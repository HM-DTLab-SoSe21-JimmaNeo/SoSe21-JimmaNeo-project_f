﻿using System;
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
        [Required]
        [DefaultValue("https://www.youtube.com/embed/")]
        public string Path { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
