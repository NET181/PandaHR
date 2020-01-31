using PandaHR.Api.Common;
using PandaHR.Api.Models.User;
using PandaHR.Api.Services.Models.User;

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
