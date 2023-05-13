using AutoMapper;
using PM.MODEL;
using PM.MODEL.Models.UserMaster;
using PM.MODEL.Models.UserMaster.UserMasterDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Infrastructure.AutoMapper
{
    public class MasterMapper : Profile
    {
        public MasterMapper()
        {
            CreateMap<UserMasterRequest, UserMaster>();
            CreateMap<UserMaster, UserMasterDTO>();
        }

    }
}
