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
            CreateMap<Answer, AnswerDTO>()
                .ForMember(answerDto => answerDto.Answer, opts => opts.MapFrom(obj => obj.AnswerText));
            CreateMap<AnswerDTO, Answer>()
                .ForMember(answer => answer.AnswerText, opts => opts.MapFrom(obj => obj.Answer));

            // FurtherLink
            CreateMap<FurtherLink, FurtherLinkDTO>();
            CreateMap<FurtherLinkDTO, FurtherLink>();

            // LectureContent
            CreateMap<LectureContent, LectureContentDTO>();
            CreateMap<LectureContentDTO, LectureContent>();

            // hier ist irgendwas mit "Test" komisch, bitte anschauen
            // Lecture
            CreateMap<Lecture, LectureDTO>()
                .ForMember(lectureDto => lectureDto.Test, opts => opts.MapFrom(obj => obj.Test));
            CreateMap<LectureDTO, Lecture>()
                .ForMember(lecture => lecture.Test, opts => opts.MapFrom(obj => obj.Test.ToList())); 
            CreateMap<Lecture, LectureBaseDTO>()
                .ForMember(lectureBaseDto => lectureBaseDto.Author, opts => opts.MapFrom(obj => obj.CreatedBy));
            CreateMap<LectureBaseDTO, Lecture>()
                .ForMember(lecture => lecture.CreatedBy, opts => opts.MapFrom(obj => obj.Author));

            // News
            CreateMap<News , NewsDTO>();
            CreateMap<NewsDTO, News>();
            // Wo soll der Author aus NewsDTO hin?

            // Question
            CreateMap<Question, QuestionDTO>();
            CreateMap<QuestionDTO, Question>();
            // wo soll die Explanation aus QuestionDTO hin?

            // SubjectArea
            CreateMap<SubjectArea, SubjectAreaDTO>()
                .ForMember(subjectAreaDto => subjectAreaDto.Lectures, opts => opts.MapFrom(obj => obj.Lectures.ToList()));
            CreateMap<SubjectAreaDTO, SubjectArea>()
                .ForMember(subjectAreaObj => subjectAreaObj.Lectures, opts => opts.MapFrom(obj => obj.Lectures.ToList()));
            // ich hoffe es kommen keine Probleme auf, wenn auf die BaseDTO und nicht auf die Haupt DTO gematched wird? 
            // evtl in DTO-Klasse anpassen

            // TestContent
            CreateMap<TestContent, TestContentDTO>();
            CreateMap<TestContentDTO, TestContent>();

            // Test
            CreateMap<Test, TestDTO>();
            CreateMap<TestDTO, Test>();

            CreateMap<Test, TestBaseDTO>()
                .ForMember(testBaseDto => testBaseDto.Author, opts => opts.MapFrom(obj => obj.CreatedBy));
            CreateMap<TestBaseDTO, Test>()
                .ForMember(test => test.CreatedBy, opts => opts.MapFrom(obj => obj.Author));

            // User
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            // muss hier Rolle angefuehrt werden?

            // LoginInformation TODO keine Ahnung ...
            CreateMap<LoginInformationDTO, User>()
                .ForMember(user => user.Pw, opts => opts.MapFrom(obj => obj.Pw));

           

            

        }

    }
}
