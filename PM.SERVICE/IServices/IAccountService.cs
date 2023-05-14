using PM.MODEL.Models.Login;
using PM.MODEL.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.SERVICE.IServices
{
    public interface IAccountService
    {
        Task<LoginResponse> GetLogin(LoginRequest request);
    }
}
