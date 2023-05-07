using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.MODEL;
using PM.SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] UserMaster userMaster)
        {
            _userService.AddUSer(userMaster);
            return Ok();
        }
    }
}
