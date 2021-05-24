using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SEIIApp.Server.Services;
using SEIIApp.Shared;
using SEIIApp.Server.Domain;

namespace SEIIApp.Server.Controllers
{
    [ApiController]
    [Route("api/")] 
    public class UserController : Controller
    {
        private UserService UserService { get; set; }

        public UserController(UserService userService)
        {
            this.UserService = userService;
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

            UserDTO result = new UserDTO();
            result.Name = user.Name;
            result.Role = user.Role;
            return Ok(result);
        }

        [HttpGet("ShowUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDTO[]> ShowUsers()
        {
            var allUser = UserService.GetAllUser();
            UserDTO[] result = new UserDTO[allUser.Length];

            for (int i = 0; i < result.Length; i++)
            {
                UserDTO r = new UserDTO();
                r.Name = allUser[i].Name;
                r.Role = allUser[i].Role;
                result[i] = r;
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("RegisterStudent")]
        public ActionResult<UserDTO> RegisterStudent([FromBody] LoginInformationDTO ri)
        {

            var userInList = UserService.GetUserWithName(ri.User.Name);
            if (userInList != null) return BadRequest();

            User newUser = new();
            newUser.Name = ri.User.Name;
            newUser.Pw = ri.Pw;
            newUser.Role = ri.User.Role;

            return Ok(UserService.AddUser(newUser));
        }


    }
}
