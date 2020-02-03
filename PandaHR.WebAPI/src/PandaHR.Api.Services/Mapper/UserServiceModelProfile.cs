using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class UserServiceModelProfile : AutoMapperProfile
    {
        public UserServiceModelProfile()
        {
            CreateMap<UserDTO, UserServiceModel>();

            CreateMap<UserServiceModel, UserDTO>();

            CreateMap<UserCreationServiceModel, UserCreationDTO>();

            CreateMap<UserServiceModel, UserFullInfoDTO>();
            CreateMap<UserFullInfoDTO, UserServiceModel>();
        }
    }
}
