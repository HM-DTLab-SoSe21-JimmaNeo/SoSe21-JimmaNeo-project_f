using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using SEIIApp.Server.Domain;
using AutoMapper;

namespace SEIIApp.Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private UserService UserService { get; set; }

        private IMapper Mapper { get; set; }

        public UserController(UserService userService, IMapper mapper)
        {
            this.UserService = userService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Returns all users. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDTO[]> ShowUsers()
        {
            var allUser = UserService.GetAllUser();
            var mappedResult = Mapper.Map<UserDTO[]>(allUser);
            return Ok(mappedResult);
        }

        /// <summary>
        /// Returns the user with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetUserById([FromRoute] int id)
        {
            var user = UserService.GetUserWithId(id);
            if (user == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedResult = Mapper.Map<UserDTO>(user);
            return Ok(mappedResult);
        }

        /// <summary>
        /// Returns the user with the given id, 
        /// if the name exists and the password is correct.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> LoginUser([FromQuery] string name, [FromQuery] string pw)
        {
            var user = UserService.GetUserWithName(name);

            if (user == null) return NotFound();
            if (pw == null) return BadRequest();
            if (!user.Pw.Equals(pw.GetHashCode().ToString())) return BadRequest();

            var mappedResult = Mapper.Map<UserDTO>(user);
            return Ok(mappedResult);
        }

        /// <summary>
        /// Adds a user, if the name is available. 
        /// </summary>
        /// <param name="ri"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("register")]
        public ActionResult<UserDTO> RegisterStudent([FromBody] LoginInformationDTO ri)
        {
            var userInList = UserService.GetUserWithName(ri.User.Name);
            if (userInList != null) return BadRequest();

            var mappedUser = Mapper.Map<User>(ri.User);
            mappedUser.Pw = ri.Pw.GetHashCode().ToString();
            UserService.AddUser(mappedUser);

            return Ok(Mapper.Map<UserDTO>(mappedUser));
        }

        /// <summary>
        /// Updates a user. 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPut("change")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> ChangeUser([FromBody] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                if (userDTO.UserId == 0) return BadRequest();

                var mappedUser = Mapper.Map<User>(userDTO);
                mappedUser = UserService.UpdateUser(mappedUser);

                var mappedUserDTO = Mapper.Map<UserDTO>(mappedUser);
                return Ok(mappedUserDTO);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteStudent([FromRoute] int id)
        {
            var user = UserService.GetUserWithId(id);
            if (user == null) return StatusCode(StatusCodes.Status404NotFound);

            UserService.RemoveUser(user);
            return Ok();
        }
    }
}
