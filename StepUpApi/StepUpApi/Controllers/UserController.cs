using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.User;
using StepUpApi.Models;
using StepUpApi.Services;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResponse<User>>> RegisterUser(CreateUserDto userDto)
        {
            return Ok(await _userService.RegisterUser(userDto));
        }
}
}
