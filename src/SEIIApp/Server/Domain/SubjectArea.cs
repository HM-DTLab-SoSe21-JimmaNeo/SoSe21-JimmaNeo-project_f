using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Server.Domain
{
    public class SubjectArea
    {
        [Key]
        public int SAId { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public List<Lecture> Lectures { get; set; }
    }
}
