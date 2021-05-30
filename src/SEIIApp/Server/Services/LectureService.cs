using System;
using System.Collections.Generic;
using System.Linq;
using SEIIApp.Server.Domain;
using System.Threading.Tasks;
using SEIIApp.Server.DataAccess;
using AutoMapper;

namespace SEIIApp.Server.Services
{
    public class LectureService
    {
        private DatabaseContext DatabaseContext { get; set; }

        //private IMapper Mapper { get; set; }

        public LectureService(DatabaseContext db) //, IMapper mapper
        {
            this.DatabaseContext = db;
            //this.Mapper = mapper;
        }

        private IQueryable<Lecture> GetQueryableForLecture()
        {
            return DatabaseContext.Lectures;
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

    }
}
