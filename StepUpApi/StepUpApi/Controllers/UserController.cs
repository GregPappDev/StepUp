using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.User;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Authorize (Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<User>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        
        [Authorize (Roles = "admin")]
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<User>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }
        
        [Authorize (Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<User>>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [Authorize (Roles = "admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResponse<User>>> RegisterUser(CreateUserDto userDto)
        {
            return Ok(await _service.RegisterUser(userDto));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginUserDto userDto)
        {
            return Ok(await _service.Login(userDto));
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<User>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
