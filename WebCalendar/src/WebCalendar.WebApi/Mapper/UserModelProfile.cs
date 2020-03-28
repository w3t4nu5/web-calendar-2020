using WebCalendar.Common;
using WebCalendar.Services.Models.User;
using WebCalendar.WebApi.Models.User;

namespace WebCalendar.WebApi.Mapper
{
    public class UserModelProfile : AutoMapperProfile
    {
        public UserModelProfile()
        {
            CreateMap<UserRegistrationRequestModel, UserRegisterServiceModel>();
        }
    }
}