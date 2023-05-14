using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.MODEL.Models.Login;
using PM.SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<Dictionary<string, object>> Login(LoginRequest request)
        {
            var loginInfo = await _accountService.GetLogin(request);
            if (loginInfo != null)
                return APIResponse("Success", loginInfo);

            return FailureResponse("UnAuthenticated User", null);
        }
    }
}
