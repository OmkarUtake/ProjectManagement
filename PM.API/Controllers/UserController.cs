using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.MODEL.Models.UserMaster;
using PM.SERVICE.IServices;
using PM.SERVICE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("AddUser")]
        public async Task<Dictionary<string, object>> AddUser(UserMasterRequest request)
        {
            var data = await _userService.AddUSer(request);
            return APIResponse("Success", data);
        }
    }
}
