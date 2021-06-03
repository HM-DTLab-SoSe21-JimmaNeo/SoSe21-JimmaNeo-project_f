using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
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
        public int CtId { get; set; }

        public Test SolvedTest { get; set; }

        public User Student { get; set; }

        public int ReachedPoints { get; set; }

    }
}
