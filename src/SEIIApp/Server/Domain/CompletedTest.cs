using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class CompletedTest
    {
        [Key]
        public int CtId;

        public Test SolvedTest;

        public User Student;

        public int ReachedPoints;

    }
}
