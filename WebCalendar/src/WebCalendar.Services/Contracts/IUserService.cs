using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebCalendar.Services.Models.User;

namespace WebCalendar.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> GetAllAsync();
        Task<UserServiceModel> GetByIdAsync(Guid id);
        Task UpdateAsync(UserEditionServiceModel entity);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(UserServiceModel entity);

        Task<IdentityResult> RegisterAsync(UserRegisterServiceModel userRegisterServiceModel);
        Task<SignInResult> LoginAsync(UserLoginServiceModel userLoginServiceModel);
        Task Logout();
    }
}