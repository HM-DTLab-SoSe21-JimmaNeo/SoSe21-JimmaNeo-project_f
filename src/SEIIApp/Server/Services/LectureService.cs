using System;
using System.Collections.Generic;
using System.Linq;
using SEIIApp.Server.Domain;
using System.Threading.Tasks;
using SEIIApp.Server.DataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SEIIApp.Server.Services
{
    public class LectureService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private TestService testService { get; set; }
        private UserService userService { get; set; }

        private NewsService NewsService { get; set; }
        private IMapper Mapper { get; set; }

        public LectureService(DatabaseContext db, IMapper mapper, UserService userService, NewsService newsService, TestService testService)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
            this.userService = userService;
            this.NewsService = newsService;
            this.testService = testService;
        }

        private IQueryable<Lecture> GetQueryableForLecture()
        {
            return DatabaseContext.Lectures
                .Include(lecture => lecture.Author)
                .Include(lecture => lecture.Test)
                .Include(lecture => lecture.Content)
                .Include(lecture => lecture.Videos);
        }

        public Lecture[] GetAllLecture()
        {
            return GetQueryableForLecture().ToArray();
        }

        public Lecture GetLectureWithId(int id)
        {
            return GetQueryableForLecture().Where(lecture => lecture.LectureId == id).FirstOrDefault();
        }

        public Lecture GetLectureWithTopic(string topic)
        {
            return GetQueryableForLecture().Where(lecture => lecture.Topic.Equals(topic)).FirstOrDefault();
        }

        public Lecture AddLecture(Lecture lecture)
        {
            
           if (lecture.Author == null)
            {
                return null;
            }
           else lecture.Author = userService.GetUserWithId(lecture.Author.UserId);
            if (lecture.Test != null && lecture.Test.TestId != 0)
            {
                lecture.Test = testService.GetTestWithId(lecture.Test.TestId);
            }
            else
            {
                lecture.Test = null;
            }
            DatabaseContext.Lectures.Add(lecture);
            DatabaseContext.SaveChanges();

            NewsService.AddNews(new News()
            {
                Topic = "New Lecture",
                Content = $"A new Lecture, named {lecture.Topic}, was uploaded to this platform. The Lecture was created by {lecture.Author.Name}.",
                DateOfCreation = DateTime.Now,
                Creator = "System",
                Tags =  "New,Topic, Learning, Knowledge" 
            }); 

            return lecture;
        }

        public Lecture UpdateLecture(Lecture lecture)
        {
            var exsistingLecture = GetLectureWithId(lecture.LectureId);
            var test = exsistingLecture.Test;
            Mapper.Map(lecture, exsistingLecture);
            if (lecture.Test != null && lecture.Test.TestId != 0) exsistingLecture.Test = testService.GetTestWithId(lecture.Test.TestId);
            else exsistingLecture.Test = null;
            if (test != null) DatabaseContext.Entry(test).State = EntityState.Unchanged;
            DatabaseContext.Update(exsistingLecture);
            DatabaseContext.SaveChanges();
            NewsService.AddNews(new News()
            {
                Topic = $"Updated {lecture.Topic}",
                Content = $"The Lecture \"{lecture.Topic}\" has been updated. The Lectrue was updated by {lecture.Author.Name}.",
                DateOfCreation = DateTime.Now,
               Creator = "System",
               Tags = "New,Topic, Learning, Knowledge"
           });

            return exsistingLecture;
        }

        public void RemoveLecture(Lecture lecture)
        {
            DatabaseContext.Lectures.Remove(lecture);
            DatabaseContext.SaveChanges();
        }

    }
}
