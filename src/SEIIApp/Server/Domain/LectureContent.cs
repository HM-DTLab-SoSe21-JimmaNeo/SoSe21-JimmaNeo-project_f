using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class LectureContent
    {
        [Key]
        public int LcId { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }
    }
}
