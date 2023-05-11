using PM.MODEL;
using PM.MODEL.Models.ResponseModel;
using PM.MODEL.Models.UserMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.SERVICE.IServices
{
    public interface IUserService
    {
        Task<ResponseModel> AddUSer(UserMasterRequest request);
    }
}
