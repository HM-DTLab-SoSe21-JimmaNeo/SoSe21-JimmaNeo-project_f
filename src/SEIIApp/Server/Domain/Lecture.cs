using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }

        public string Topic { get; set; }

        public string Text { get; set; }

        public DateTime DateOfCreation { get; set; }

        public User Author { get; set; }

        public List<PictureContent> Content { get; set; }

        public List<VideoContent> Videos{ get; set; }

        public Test Test { get; set; }
    }
}
