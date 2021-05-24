﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Server.Domain
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }

        public string Topic { get; set; }

        public string Text { get; set; }

        public DateTime DateOfCreation { get; set; }

        public User CreatedBy { get; set; }

        public List<LectureContent> Content { get; set; }

        public Test Test { get; set; }
    }
}