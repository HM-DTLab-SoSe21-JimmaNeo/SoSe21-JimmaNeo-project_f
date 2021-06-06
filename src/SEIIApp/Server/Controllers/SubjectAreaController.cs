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
    [Route("api/subjectareas")]
    public class SubjectAreaController : Controller
    {
        private SubjectAreaService SubjectAreaService { get; set; }

        private IMapper Mapper { get; set; }

        public SubjectAreaController(SubjectAreaService subjectAreaService, IMapper mapper)
        {
            this.SubjectAreaService = subjectAreaService;
            this.Mapper = mapper;
        }

        [HttpGet("ShowSubjectArea")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SubjectAreaDTO[]> ShowSubjectAreas()
        {
            var allSubjectAreas = SubjectAreaService.GetAllSubjectAreas();
            var mappedResult = Mapper.Map<SubjectAreaDTO[]>(allSubjectAreas);
            return Ok(mappedResult);
        }

        [HttpGet("SearchSubjectAreaID/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubjectAreaDTO> SearchSubjectArea([FromRoute] int id)
        {
            var subjectAreaInList = SubjectAreaService.GetSubjectAreaWithId(id);
            if (subjectAreaInList == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedResult = Mapper.Map<SubjectAreaDTO>(subjectAreaInList);
            return Ok(mappedResult);
        }

        [HttpGet("SearchSubjectAreaTopic/{topic}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubjectAreaDTO> SearchSubjectArea([FromRoute] string topic)
        {
            var subjectAreaInList = SubjectAreaService.GetSubjectAreaWithTopic(topic);
            if (subjectAreaInList == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedResult = Mapper.Map<SubjectAreaDTO>(subjectAreaInList);
            return Ok(mappedResult);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("ChangeSubjectArea")]
        public ActionResult<SubjectAreaDTO> AddOrUpdateSubjectArea([FromBody] SubjectAreaDTO subjectAreaDTO)
        {
            if (ModelState.IsValid)
            {
                var mappedSubjectArea = Mapper.Map<SubjectArea>(subjectAreaDTO);

                if (mappedSubjectArea.SAId == 0)
                {
                    mappedSubjectArea = SubjectAreaService.AddSubjectArea(mappedSubjectArea);
                }
                else
                {
                    mappedSubjectArea = SubjectAreaService.UpdateSubjectArea(mappedSubjectArea);
                }
                if (mappedSubjectArea == null)
                {
                    return BadRequest();
                }

                var mappedSubjectAreaDTO = Mapper.Map<SubjectAreaDTO>(mappedSubjectArea);

                return Ok(mappedSubjectAreaDTO);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteSubjectArea/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteSubjectArea([FromRoute] int id)
        {
            var subjectArea = SubjectAreaService.GetSubjectAreaWithId(id);
            if (subjectArea == null) return StatusCode(StatusCodes.Status404NotFound);

            SubjectAreaService.RemoveSubjectArea(subjectArea);
            return Ok();
        }

    }
}
