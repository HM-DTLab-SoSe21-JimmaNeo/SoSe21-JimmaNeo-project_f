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

        private IMapper Mapper { get; set; }

        public LectureService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<Lecture> GetQueryableForLecture()
        {
            return DatabaseContext.Lectures
                .Include(lecture => lecture.CreatedBy)
                .Include(lecture => lecture.Test)
                .Include(lecture => lecture.Content);
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
