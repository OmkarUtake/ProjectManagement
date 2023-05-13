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

            if (data.Message == "Success")
                return APIResponse("Success", data.Data);

            return FailureResponse("Failure", null);
        }

        [HttpPost("Users")]
        public async Task<Dictionary<string, object>> Users()
        {
            var allUsers = await _userService.GetAllUsers();

            if (allUsers.Message == "Success")
                return APIResponse("Success", allUsers.Data);

            return FailureResponse("Failed", null);
        }

        [HttpPost("Getuser/{userId}")]
        public async Task<Dictionary<string, object>> User(int userId)
        {
            var allUsers = await _userService.GetUserById(userId);

            if (allUsers.Message == "Success")
                return APIResponse("Success", allUsers.Data);

            return FailureResponse("Failed", null);
        }

        [HttpPost("UpdateUser")]
        public async Task<Dictionary<string, object>> User(UserMasterRequest request)
        {
            var updateUser = await _userService.UpdateUser(request);

            if (updateUser.Message == "Success")
                return APIResponse("Success", updateUser.Data);

            return FailureResponse("Failed", updateUser.Message);
        }
    }
}
