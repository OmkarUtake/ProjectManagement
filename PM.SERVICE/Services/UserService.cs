using AutoMapper;
using PM.DATABASE.Infrastructure;
using PM.MODEL;
using PM.MODEL.Models.ResponseModel;
using PM.MODEL.Models.UserMaster;
using PM.SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.SERVICE.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork
                          , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseModel> AddUSer(UserMasterRequest request)
        {
            var response = new ResponseModel();
            try
            {
                var userMaster = _mapper.Map<UserMasterRequest, UserMaster>(request);
                userMaster.CreatedBy = 1;
                userMaster.CreatedDate = DateTime.Now;
                var savedData = await _unitOfWork.userRepository.AddAsync(userMaster);
                _unitOfWork.userRepository.SaveChanges();
                response.Message = "Success";
                response.Data = savedData;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
