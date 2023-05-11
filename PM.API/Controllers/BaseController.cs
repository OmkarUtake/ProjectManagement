using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [HttpPost("Now")]
        public Dictionary<string, object> APIResponse(string msgCode, object result)
        {
            var response = new Dictionary<string, object>();
            response.Add("message", 200);
            response.Add("Data", result);

            return response;
        }
    }
}
