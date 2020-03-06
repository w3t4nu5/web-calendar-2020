using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.User;
using Task = System.Threading.Tasks.Task;

namespace WebCalendar.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public Task<IEnumerable<UserServiceModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserServiceModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(UserServiceModel entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserServiceModel entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(UserServiceModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterAsync(UserRegisterServiceModel userRegisterServiceModel)
        {
            User user = _mapper.Map<UserRegisterServiceModel, User>(userRegisterServiceModel);
            IdentityResult result = await _userManager.CreateAsync(user, userRegisterServiceModel.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return result;

        }

        public async Task<SignInResult> LoginAsync(UserLoginServiceModel userLoginServiceModel)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(
                userLoginServiceModel.Email,
                userLoginServiceModel.Password,
                isPersistent: true,
                false
            );
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}