using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess
{
    public class DatabaseContext : DbContext
    {
         public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        public DbSet<Domain.CompletedTest> CompletedTests { get; set; }

        public DbSet<Domain.User> User { get; set; }

        public DbSet<Domain.SubjectArea> SubjectAreas { get; set; }

        public DbSet<Domain.Lecture> Lectures { get; set; }

        public DbSet<Domain.Test> Tests { get; set; }

        public DbSet<Domain.News> News{ get; set; }

        public DbSet<Domain.ToDo> ToDo { get; set; }

    }
}
