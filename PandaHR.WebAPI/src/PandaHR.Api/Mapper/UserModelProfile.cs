using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.Models.User;
using PandaHR.Api.Services.Models.User;

namespace PandaHR.Api.Mapper
{
    public class UserModelProfile : AutoMapperProfile
    {
        public UserModelProfile()
        {
            CreateMap<UserServiceModel, UserResponseModel>();

            CreateMap<UserFullInfoResponse, UserFullInfoServiceModel>();

            CreateMap<UserFullInfoDTO, UserFullInfoServiceModel>();

            CreateMap<UserFullInfoServiceModel, UserFullInfoResponse>();
        }
    }
}
