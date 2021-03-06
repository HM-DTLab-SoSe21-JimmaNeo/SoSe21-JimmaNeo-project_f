using AutoMapper;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class DomainMapper : Profile
    {

        public DomainMapper()
        {

            // Answer
            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerDTO, Answer>();

            // FurtherLink
            CreateMap<FurtherLink, FurtherLinkDTO>();
            CreateMap<FurtherLinkDTO, FurtherLink>();

            // YT-Videos
            CreateMap<VideoContent, VideoContentDTO>();
            CreateMap<VideoContentDTO, VideoContent>();

            // Content
            CreateMap<PictureContent, PictureContentDTO>();
            CreateMap<PictureContentDTO, PictureContent>();

            // Lecture
            CreateMap<Lecture, Lecture>()
                .ForMember(lecture => lecture.LectureId, options => options.Ignore())
                .ForMember(lecture => lecture.Author, options => options.Ignore()); ;

            CreateMap<Lecture, LectureDTO>();
            CreateMap<LectureDTO, Lecture>(); 

            CreateMap<Lecture, LectureBaseDTO>();
            CreateMap<LectureBaseDTO, Lecture>();

            // News
            CreateMap<News, News>();
            CreateMap<News , NewsDTO>();
            CreateMap<NewsDTO, News>();

            // Question
            CreateMap<Question, QuestionDTO>();
            CreateMap<QuestionDTO, Question>();

            // SubjectArea
            CreateMap<SubjectArea, SubjectAreaDTO>();
            CreateMap<SubjectAreaDTO, SubjectArea>();
            CreateMap<SubjectArea, SubjectArea>();

            // Test
            CreateMap<Test, Test>()
                .ForMember(test => test.TestId, options => options.Ignore())
                .ForMember(test => test.Author, options => options.Ignore());

            CreateMap<Test, TestDTO>();
            CreateMap<TestDTO, Test>();

            CreateMap<Test, TestBaseDTO>();
            CreateMap<TestBaseDTO, Test>();


            //CompletedTest
            CreateMap<CompletedTest, CompletedTestDTO>();
            CreateMap<CompletedTestDTO, CompletedTest>();

            // User
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            //ToDo
            CreateMap<ToDo, ToDoDTO>();
            CreateMap<ToDoDTO, ToDo>();
            CreateMap<ToDo, ToDo>()
                .ForMember(todo => todo.ToDoID, options => options.Ignore())
                .ForMember(todo => todo.Author, options => options.Ignore());
        }

    }
}
