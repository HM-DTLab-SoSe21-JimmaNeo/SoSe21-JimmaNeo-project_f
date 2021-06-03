using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SEIIApp.Server.Domain
{
    public class VideoContent
    {
        [Key]
        public int VideoId { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }
    }
}
