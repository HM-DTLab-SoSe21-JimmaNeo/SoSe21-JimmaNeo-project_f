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
    public class SubjectAreaService
    {
        private DatabaseContext DatabaseContext { get; set; }

        private IMapper Mapper { get; set; }

        public SubjectAreaService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<SubjectArea> GetQueryableForSubjectArea()
        {
            return DatabaseContext.SubjectAreas
                .Include(subjectArea => subjectArea.Lectures);
        }

        /// <summary>
        /// Returns a list with all subjectAreas and the included lectures.
        /// </summary>
        /// <returns></returns>
        public List<SubjectArea> GetAllSubjectAreas()
        {
            return GetQueryableForSubjectArea().ToList();
        }

        /// <summary>
        /// Returns a subjectArea with specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SubjectArea GetSubjectAreaWithId(int id)
        {
            return GetQueryableForSubjectArea().Where(subjectArea => subjectArea.SAId == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns a subjectArea with specific topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public SubjectArea GetSubjectAreaWithTopic(string topic)
        {
            return GetQueryableForSubjectArea().Where(subjectArea => subjectArea.Topic.Equals(topic)).FirstOrDefault();
        }

        /// <summary>
        /// Adds given subjectArea to database.
        /// </summary>
        /// <param name="subjectArea"></param>
        /// <returns></returns>
        public SubjectArea AddSubjectArea(SubjectArea subjectArea)
        {
            DatabaseContext.SubjectAreas.Add(subjectArea);
            DatabaseContext.SaveChanges();
            return subjectArea;
        }

        /// <summary>
        /// Updates given subjectArea in database.
        /// </summary>
        /// <param name="subjectArea"></param>
        /// <returns></returns>
        public SubjectArea UpdateSubjectArea(SubjectArea subjectArea)
        {
            var exsistingSubjectArea = GetSubjectAreaWithId(subjectArea.SAId);
            //Mapper.Map(lecture, exsistingLecture);
            exsistingSubjectArea.Topic = subjectArea.Topic;
            exsistingSubjectArea.Description = subjectArea.Description;
            exsistingSubjectArea.Lectures = subjectArea.Lectures;
            DatabaseContext.SubjectAreas.Update(exsistingSubjectArea);
            DatabaseContext.SaveChanges();
            return exsistingSubjectArea;
        }

        /// <summary>
        /// Deletes given subjectArea from database.
        /// </summary>
        /// <param name="subjectArea"></param>
        /// <returns></returns>
        public void RemoveSubjectArea(SubjectArea subjectArea)
        {
            DatabaseContext.SubjectAreas.Remove(subjectArea);
            DatabaseContext.SaveChanges();
        }

    }
}
