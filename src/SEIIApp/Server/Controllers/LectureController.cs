using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using SEIIApp.Server.Domain;
using AutoMapper;

namespace SEIIApp.Server.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LectureController : Controller
    {
        private LectureService LectureService { get; set; }

        private IMapper Mapper { get; set; }

        public LectureController(LectureService lectureService, IMapper mapper)
        {
            this.LectureService = lectureService;
            this.Mapper = mapper;
        }

        [HttpGet("ShowLectures")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDTO[]> ShowLectures()
        {
            var allLectures = LectureService.GetAllLecture();
            var mappedResult = Mapper.Map<LectureBaseDTO[]>(allLectures);
            return Ok(mappedResult);
        }

        [HttpGet("SearchLecture")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDTO[]> SearchLecture([FromQuery] string topic)
        {
            var lectureInList = LectureService.GetLectureWithTopic(topic);
            if (lectureInList == null) return BadRequest();
            var mappedResult = Mapper.Map<LectureBaseDTO[]>(lectureInList);
            return Ok(mappedResult);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("AddLecture")]
        public ActionResult<LectureDTO> AddLecture([FromQuery] string topic, [FromQuery] string text)
        {
            var lectureInList = LectureService.GetLectureWithTopic(topic);
            if (lectureInList != null) return BadRequest();
            // TODO ueberarbeitern!!!
            var allLectures = LectureService.GetAllLecture();
            int maxID = 1;
            foreach (Lecture x in allLectures)
            {
                if(maxID < x.LectureId)
                {
                    maxID = x.LectureId;
                }
            }
            Lecture lecture = new Lecture();
            lecture.LectureId = maxID + 1;
            lecture.Topic = topic;
            lecture.Text = text;

            var mappedLecture = Mapper.Map<Lecture>(lecture);

            return Ok(LectureService.AddLecture(mappedLecture));
        }

    }
}
