using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Server.Domain
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public User CreatedBy { get; set; }

        public List<TestContent> TestContent { get; set; }

        public List<Question> Questions { get; set; }

        public List<FurtherLink> FurtherLinks { get; set; }
    }
}
