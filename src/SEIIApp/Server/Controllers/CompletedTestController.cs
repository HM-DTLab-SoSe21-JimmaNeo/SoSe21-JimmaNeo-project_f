using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared;

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

        /// <summary>
        /// Returns a completed test with the given id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all completed tests, which were solved by the user with the given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all completed tests by the given test-id.  
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all completed tests, which were created by the author with the given id.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a completed test.
        /// </summary>
        /// <param name="completedTest"></param>
        /// <returns></returns>
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
