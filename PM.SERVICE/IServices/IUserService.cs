using PM.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.SERVICE.IServices
{
    public interface IUserService
    {
        Task AddUSer(UserMaster userMaster);
    }
}
