using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCalendar.Common.Contracts;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.User;
using WebCalendar.WebApi.Models.User;

namespace WebCalendar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // POST: /api/user/registration
        [HttpPost("registration")]
        public async Task<ActionResult<IdentityResult>> Register([FromBody] UserRegistrationRequestModel model)
        {
            UserRegisterServiceModel userRegisterServiceModel = _mapper
                .Map<UserRegistrationRequestModel, UserRegisterServiceModel>(model);
            IdentityResult result = await _userService.RegisterAsync(userRegisterServiceModel);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            
            //fix. CreateAtAction return user
            return Ok(result);
        }
    }
}