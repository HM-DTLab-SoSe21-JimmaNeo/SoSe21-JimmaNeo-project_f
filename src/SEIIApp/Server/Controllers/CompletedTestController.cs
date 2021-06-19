using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Controllers
{
    [ApiController]
    [Route("api/completedtest")]
    public class CompletedTestController : ControllerBase
    {

        private CompletedTestService CompletedTestService { get; set; }

        private IMapper Mapper { get; set; }

        public CompletedTestController(CompletedTestService completedTestService, IMapper mapper)
        {
            this.CompletedTestService = completedTestService;
            this.Mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CompletedTestDTO> GetCompletedTest([FromRoute] int id)
        {
            var test = CompletedTestService.GetCompletedTestWithId(id);
            if (test == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedResult = Mapper.Map<CompletedTestDTO>(test);
            return Ok(mappedResult);
        }

        [HttpGet("userId/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CompletedTestDTO[]> GetCompletedTestsWithUser([FromRoute] int userId)
        {
            var tests = CompletedTestService.GetCompletedTestsWithUserId(userId);
            if (tests == null || tests.Length == 0) return StatusCode(StatusCodes.Status404NotFound);

            var mappedResult = Mapper.Map<CompletedTestDTO[]>(tests);
            return Ok(mappedResult);
        }

        [HttpGet("testId/{testId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CompletedTestDTO[]> GetCompletedTestsWithTestId([FromRoute] int testId)
        {          
            var tests = CompletedTestService.GetCompletedTestsWithTestId(testId);
            if (tests == null || tests.Length == 0) return StatusCode(StatusCodes.Status404NotFound);

            var mappedResult = Mapper.Map<CompletedTestDTO[]>(tests);
            return Ok(mappedResult);
        }

        [HttpGet("authorId/{authorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CompletedTestDTO[]> GetCompletedTestWithAuthorId([FromRoute] int authorId)
        {
            var tests = CompletedTestService.GetCompletedTestsWithAuthorId(authorId);
            if (tests == null || tests.Length == 0) return StatusCode(StatusCodes.Status404NotFound);

            var mappedResult = Mapper.Map<CompletedTestDTO[]>(tests);
            return Ok(mappedResult);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CompletedTestDTO> AddTest([FromBody] CompletedTestDTO completedTest)    
        {
            if (ModelState.IsValid && completedTest.CtId == 0)
            {
                var mappedTest = Mapper.Map<CompletedTest>(completedTest);

                mappedTest = CompletedTestService.AddCompletedTest(mappedTest);

                if (mappedTest == null) return StatusCode(StatusCodes.Status404NotFound);
                    
                var mappedTestDTO = Mapper.Map<CompletedTestDTO>(mappedTest);
                return Ok(mappedTestDTO);
            }
            return BadRequest(ModelState);

        }

    }
}
