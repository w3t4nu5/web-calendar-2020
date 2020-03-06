using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebCalendar.Services.Models.User;

namespace WebCalendar.Services.Contracts
{
    public interface IUserService : IAsyncService<UserServiceModel>
    {
        Task<IdentityResult> RegisterAsync(UserRegisterServiceModel userRegisterServiceModel);
        Task<SignInResult> LoginAsync(UserLoginServiceModel userLoginServiceModel);
        Task Logout();
    }
}