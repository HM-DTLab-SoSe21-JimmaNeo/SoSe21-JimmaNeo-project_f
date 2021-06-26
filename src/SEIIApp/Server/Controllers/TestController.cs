using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared;

namespace SEIIApp.Server.Controllers
{

  [ApiController]
  [Route("api/tests")]
  public class TestController : ControllerBase
  {

    private TestService TestService { get; set; }

    private IMapper Mapper { get; set; }


    public TestController(TestService testService, IMapper mapper)
    {
      this.TestService = testService;
      this.Mapper = mapper;
    }

    /// <summary>
    /// Returns all tests. 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<TestBaseDTO> GetAllTests()
    {
      var tests = TestService.GetAllTests();
      var mappedResult = Mapper.Map<TestBaseDTO[]>(tests);
      return Ok(mappedResult);
    }
    
    /// <summary>
    /// Returns the test with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TestDTO> GetTest([FromRoute] int id)
    {
      var test = TestService.GetTestWithId(id);
      if (test == null) return StatusCode(StatusCodes.Status404NotFound);

      var mappedTest = Mapper.Map<TestDTO>(test);
      return Ok(mappedTest);
    }
    
    /// <summary>
    /// Returns the test with the given topic. 
    /// </summary>
    /// <param name="topic"></param>
    /// <returns></returns>
    [HttpGet("topic/{topic}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TestDTO> GetTestTopic([FromRoute] string topic)
    {
      var test = TestService.GetTestWithTopic(topic);
      if (test == null) return StatusCode(StatusCodes.Status404NotFound);

      var mappedTest = Mapper.Map<TestDTO>(test);
      return Ok(mappedTest);
    }

    /// <summary>
    /// Adds or updates a test.
    /// </summary>
    /// <param name="testDTO"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TestDTO> AddOrUpdateTest([FromBody] TestDTO testDTO)
    {
      if (ModelState.IsValid)
      {
        var mappedTest = Mapper.Map<Test>(testDTO);

        if (mappedTest.TestId == 0)
        {
          mappedTest = TestService.AddTest(mappedTest);
          if (mappedTest == null) return StatusCode(StatusCodes.Status404NotFound);
        }
        else
        {
          mappedTest = TestService.UpdateTest(mappedTest);
        }

        var mappedTestDTO = Mapper.Map<TestDTO>(mappedTest);
        return Ok(mappedTestDTO);
      }
      return BadRequest(ModelState);
    }

    /// <summary>
    /// Removes a test.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteTest([FromRoute] int id)
    {
      var test = TestService.GetTestWithId(id);
      if (test == null) return StatusCode(StatusCodes.Status404NotFound);

      TestService.RemoveTest(test);
      return Ok();
    }

  }
}
