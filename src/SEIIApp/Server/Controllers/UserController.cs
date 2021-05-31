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

        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> LoginUser([FromQuery] string name, [FromQuery] string pw)
        {
            var user = UserService.GetUserWithName(name);

            if (user == null) return NotFound();
            if (!user.Pw.Equals(pw.GetHashCode().ToString())) return BadRequest();

            var mappedResult = Mapper.Map<UserDTO>(user);
            return Ok(mappedResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDTO[]> ShowUsers()
        {
            var allUser = UserService.GetAllUser();
            var mappedResult = Mapper.Map<UserDTO[]>(allUser);
            return Ok(mappedResult);
        }

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

        [HttpPut("change")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> ChangeStudent([FromBody] UserDTO userDTO)
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
