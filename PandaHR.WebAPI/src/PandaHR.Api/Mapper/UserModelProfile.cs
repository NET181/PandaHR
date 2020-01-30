using PandaHR.Api.Common;
using PandaHR.Api.Models.User;
using PandaHR.Api.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Mapper
{
    public class UserModelProfile : AutoMapperProfile
    {
        public UserModelProfile()
        {
            CreateMap<UserServiceModel, UserResponseModel>();
        }
    }
}
