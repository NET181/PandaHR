using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.Services.Models.User;

namespace PandaHR.Api.Services.Mapper
{
    public class UserServiceModelProfile : AutoMapperProfile
    {
        public UserServiceModelProfile()
        {
            CreateMap<UserDTO, UserCreationServiceModel>();
            CreateMap<UserDTO, UserServiceModel>();
            CreateMap<UserFullInfoDTO, UserFullInfoServiceModel>();
            CreateMap<UserServiceModel, UserCreationDTO>();
            CreateMap<UserServiceModel, UserDTO>();
            CreateMap<UserCreationServiceModel, UserCreationDTO>();
            CreateMap<UserServiceModel, UserFullInfoDTO>();
            CreateMap<UserCreationServiceModel, UserDTO>();
        }
    }
}
