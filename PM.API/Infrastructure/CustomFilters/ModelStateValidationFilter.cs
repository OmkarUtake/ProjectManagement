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

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
                return;

            if (context.Result.GetType() == typeof(FileContentResult))
                return;

            var result = context.Result;
            var responseObj = new ResponseModel
            {
                Message = string.Empty,
                StatusCode = 200,
                Errors = null,
            };

            switch (result)
            {
                case OkObjectResult okresult:
                    responseObj.Data = okresult.Value;
                    break;
                //case ObjectResult objectResult:
                //    var data = (Dictionary<string, object>)(objectResult.Value);
                //    responseObj.Message = data.ContainsKey(Constants.ResponseMessageField) ? Convert.ToString(data[Constants.ResponseMessageField]) : null;
                //    responseObj.Data = data.ContainsKey(Constants.ResponseDataField) ? data[Constants.ResponseDataField] : null;
                //    break;
                case JsonResult json:
                    responseObj.Data = json.Value;
                    break;
                case OkResult _:
                case EmptyResult _:
                    responseObj.Data = null;
                    break;
                default:
                    responseObj.Data = result;
                    break;
            }

            context.Result = new JsonResult(responseObj);
        }
    }
}
