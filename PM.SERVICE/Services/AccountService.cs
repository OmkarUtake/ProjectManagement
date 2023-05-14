using Crud.UtilityHelper;
using PM.DATABASE.Infrastructure;
using PM.MODEL.Models.Login;
using PM.MODEL.Models.ResponseModel;
using PM.SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PM.SERVICE.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LoginResponse> GetLogin(LoginRequest request)
        {
            var response = new LoginResponse();
            try
            {
                var validUser = await _unitOfWork.userRepository.IsValidUser(request.EmailId, request.Password);

                if (validUser)
                {
                    var getUserName = await _unitOfWork.userRepository.GetUserName(request.EmailId);
                    var token = JWTHelper.GenerateToken(getUserName);
                    response.Name = getUserName;
                    response.Token = token;
                    return response;
                }
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
