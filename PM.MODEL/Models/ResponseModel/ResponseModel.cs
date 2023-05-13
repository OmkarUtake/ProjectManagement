using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PM.MODEL.Models.ResponseModel
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public Errors Errors { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public void Ok()
        {
            Message = "Success";
        }
        public void Ok(object result)
        {
            Data = result;
            Message = "Success";
        }
        public void Failure()
        {
            Message = "Failed";
        }
        public void Failed(string message)
        {
            Message = message;
        }
    }
}
