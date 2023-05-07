using PM.DATABASE.Infrastructure;
using PM.MODEL;
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
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUSer(UserMaster userMaster)
        {
            await _unitOfWork.userRepository.Add(userMaster);
        }
    }
}
