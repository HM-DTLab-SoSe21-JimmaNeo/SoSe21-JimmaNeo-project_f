using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public User Author { get; set; }

        public List<PictureContent> Content{ get; set; }

        public List<VideoContent> Videos { get; set; }

        public List<Question> Questions { get; set; }

        public List<FurtherLink> FurtherLinks { get; set; }
    }
}
