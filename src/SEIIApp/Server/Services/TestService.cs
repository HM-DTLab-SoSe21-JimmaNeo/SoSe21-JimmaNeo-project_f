using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Services
{
    public class TestService
    {
        private DatabaseContext DatabaseContext {get; set; }

        private IMapper Mapper { get; set; }

        public TestService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<Test> GetQueryableForTest()
        {
            return DatabaseContext.Tests
                .Include(test => test.Questions).ThenInclude(questions => questions.Answers)
                .Include(test => test.TestContent)
                .Include(test => test.FurtherLinks)
                .Include(test => test.CreatedBy);
        }

        public Test[] GetAllTests()
        {
            return GetQueryableForTest().ToArray();
        }

        public Test GetTestWithId(int id)
        {
            return GetQueryableForTest().Where(test => test.TestId == id).FirstOrDefault();
        }

        public Test AddTest(Test test)
        {
            DatabaseContext.Tests.Add(test);
            DatabaseContext.SaveChanges();
            return test;
        }

        public Test UpdateTest(Test test)
        {
            var exsistingTest = GetTestWithId(test.TestId);
            Mapper.Map(test, exsistingTest);

            DatabaseContext.Tests.Update(exsistingTest);
            DatabaseContext.SaveChanges();
            return exsistingTest;
        } 

        public void RemoveTest(Test test)
        {
            DatabaseContext.Tests.Remove(test);
            DatabaseContext.SaveChanges();
        }

    }
}
