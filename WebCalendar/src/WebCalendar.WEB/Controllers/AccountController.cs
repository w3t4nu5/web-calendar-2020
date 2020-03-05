using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCalendar.Common.Contracts;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.User;
using WebCalendar.Web.Models;

namespace WebCalendar.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            UserAccountServiceModel userAccountServiceModel = _mapper
                .Map<UserRegistrationModel, UserAccountServiceModel>(model);
            await _userService.RegisterAsync(userAccountServiceModel);
            return View(model);
        }
    }
}