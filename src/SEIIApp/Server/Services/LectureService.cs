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

        private UserService userService { get; set; }
        private IMapper Mapper { get; set; }

        public LectureService(DatabaseContext db, IMapper mapper, UserService userService)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
            this.userService = userService;
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
            lecture.Author = userService.GetUserWithId(lecture.Author.UserId);
            if(lecture.Author == null) {
                return null;
            }
            if(lecture.Author.Role != Shared.Role.Teacher) {
                return null;            
            }
            DatabaseContext.Lectures.Add(lecture);
            DatabaseContext.SaveChanges();
            return lecture;
        }

        public Lecture UpdateLecture(Lecture lecture)
        {
            var exsistingLecture = GetLectureWithId(lecture.LectureId);
            Mapper.Map(lecture, exsistingLecture);
            
            DatabaseContext.Lectures.Update(exsistingLecture);
            DatabaseContext.SaveChanges();
            return exsistingLecture;
        }

        public void RemoveLecture(Lecture lecture)
        {
            DatabaseContext.Lectures.Remove(lecture);
            DatabaseContext.SaveChanges();
        }

    }
}
