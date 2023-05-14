using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Infrastructure.CustomFilters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            LogExceptionToDatabase(context.Exception);

            context.Result = new JsonResult(new { error = context.Exception.Message });
            context.HttpContext.Response.StatusCode = 500;

        }

        public void LogExceptionToDatabase(Exception ex)
        {

        }
    }
}
