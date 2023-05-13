using AutoMapper;
using PM.DATABASE.Infrastructure;
using PM.MODEL;
using PM.MODEL.Models.ResponseModel;
using PM.MODEL.Models.UserMaster;
using PM.MODEL.Models.UserMaster.UserMasterDTO;
using PM.SERVICE.IServices;
using System;
using System.Linq;
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
                await _unitOfWork.userRepository.SaveChanges();
                response.Ok();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> GetAllUsers()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var getAllUsers = await _unitOfWork.userRepository.GetAllAsync();
                var userDtos = getAllUsers.Select(u => new UserMasterDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    EmployeeId = u.EmployeeId,
                    CountryCode = u.CountryCode,
                    MobileNo = u.MobileNo,
                    DOB = u.DOB,
                    DOJ = u.DOJ,
                    AddressLine1 = u.AddressLine1,
                    City = u.City,
                    District = u.District,
                    State = u.State,
                    Country = u.Country
                });
                response.Ok(userDtos);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> GetUserById(int userId)
        {
            var response = new ResponseModel();
            try
            {
                var user = await _unitOfWork.userRepository.GetById(userId);
                var userDto = _mapper.Map<UserMaster, UserMasterDTO>(user);
                response.Ok(userDto);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> UpdateUser(UserMasterRequest request)
        {
            var response = new ResponseModel();
            try
            {
                var user = await _unitOfWork.userRepository.GetById(request.Id);
                if (user == null)
                {
                    response.Failed("No user Found");
                    return response;
                }
                user.Name = request.Name;
                user.DOB = request.DOB;
                user.DOJ = request.DOJ;
                user.Email = request.Email;
                user.EmployeeId = request.EmployeeId;
                user.ModifiedDate = DateTime.Now;

                _unitOfWork.userRepository.Update(user);
                await _unitOfWork.userRepository.SaveChanges();
                response.Ok(user);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
