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
            CreateMap<UserCreationServiceModel, UserDTO>();

            CreateMap<UserDTO, UserServiceModel>();
            CreateMap<UserServiceModel, UserDTO>();

            CreateMap<UserFullInfoDTO, UserFullInfoServiceModel>();

            CreateMap<UserCreationServiceModel, UserCreationDTO>();
            CreateMap<UserCreationServiceModel, UserFullInfoDTO>();

            CreateMap<UserServiceModel, UserFullInfoDTO>();
            CreateMap<UserServiceModel, UserCreationDTO>();
        }
    }
}
