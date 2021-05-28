﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class TestContentDTO
    {
        [Required]
        public string Path { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

    }
}