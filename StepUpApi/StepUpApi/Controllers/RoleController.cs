using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.Role;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Role>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Role>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Role>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Role>>> Create([FromBody] UpdateRoleDto type)
        {
            return Ok(await _service.Create(type));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Role>>> Put(Guid id, [FromBody] UpdateRoleDto value)
        {
            return Ok(await _service.Update(id, value));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Role>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
