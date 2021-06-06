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
    [Route("api/lectures")]
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

        [HttpGet("SearchLectureID/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LectureDTO> SearchLecture([FromRoute] int id)
        {
            var lectureInList = LectureService.GetLectureWithId(id);
            if (lectureInList == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedResult = Mapper.Map<LectureDTO>(lectureInList);
            return Ok(mappedResult);
        }

        [HttpGet("SearchLectureTopic/{topic}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LectureDTO> SearchLecture([FromRoute] string topic)
        {
            var lectureInList = LectureService.GetLectureWithTopic(topic);
            if (lectureInList == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedResult = Mapper.Map<LectureDTO>(lectureInList);
            return Ok(mappedResult);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("ChangeLecture")]
        public ActionResult<LectureDTO> AddOrUpdateLecture([FromBody] LectureDTO lectureDTO)
        {
            if (ModelState.IsValid)
            {
                var mappedLecture = Mapper.Map<Lecture>(lectureDTO);

                if (mappedLecture.LectureId == 0)
                {
                    mappedLecture = LectureService.AddLecture(mappedLecture);
                }
                else
                {
                    mappedLecture = LectureService.UpdateLecture(mappedLecture);
                }
                if (mappedLecture == null)
                {
                    return BadRequest();
                }

                var mappedLectureDTO = Mapper.Map<LectureDTO>(mappedLecture);
                
                return Ok(mappedLectureDTO);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteLecture/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteLecture([FromRoute] int id)
        {
            var lecture = LectureService.GetLectureWithId(id);
            if (lecture == null) return StatusCode(StatusCodes.Status404NotFound);

            LectureService.RemoveLecture(lecture);
            return Ok();
        }

    }
}
