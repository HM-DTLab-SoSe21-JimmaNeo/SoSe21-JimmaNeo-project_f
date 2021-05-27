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
    public class UserController : Controller
    {
        private UserService UserService { get; set; }

        private IMapper Mapper { get; set; }

        public UserController(UserService userService, IMapper mapper)
        {
            this.UserService = userService;
            this.Mapper = mapper;
        }

        [HttpGet("LoginUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> LoginUser([FromQuery] string name, [FromQuery] string pw)
        {
            var user = UserService.GetUserWithName(name);

            if (user == null) return NotFound();
            if (!user.Pw.Equals(pw)) return BadRequest();

            var mappedResult = Mapper.Map<UserDTO>(user);
            return Ok(mappedResult);
        }

        [HttpGet("ShowUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDTO[]> ShowUsers()
        {
            var allUser = UserService.GetAllUser();
            var mappedResult = Mapper.Map<UserDTO[]>(allUser);
            return Ok(mappedResult);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("RegisterStudent")]
        public ActionResult<UserDTO> RegisterStudent([FromBody] LoginInformationDTO ri)
        {
            var userInList = UserService.GetUserWithName(ri.User.Name);
            if (userInList != null) return BadRequest();

            var mappedUser = Mapper.Map<User>(ri.User);
                   
            return Ok(UserService.AddUser(mappedUser));
        }


    }
}
