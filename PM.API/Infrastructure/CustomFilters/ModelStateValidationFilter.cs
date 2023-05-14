using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PM.MODEL.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.CustomFilters
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                if (!context.ModelState.IsValid)
                {
                    var errors = context.ModelState.Keys.Where(k => context.ModelState[k].Errors.Count > 0).
                        Select(k =>
                        new Errors { Error = k, ErrorMessages = context.ModelState[k].Errors.Select(p => p.ErrorMessage).ToArray() }).ToList();

                    var responseObj = new ResponseModel
                    {
                        Message = "Bad Request",
                        StatusCode = 400,
                        Errors = errors
                    };

                    context.Result = new JsonResult(responseObj)
                    {
                        StatusCode = 400
                    };
                }
            }
        }
    }
}
