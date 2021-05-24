﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Server.Domain
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        public string Topic { get; set; }

        public string Content { get; set; }

        public DateTime DateOfCreation { get; set; }


    }
}