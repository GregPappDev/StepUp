using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.Service;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Service>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Service>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Service>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Service>>> Create([FromBody] UpdateServiceDto type)
        {
            return Ok(await _service.Create(type));
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Service>>> Put(Guid id, [FromBody] UpdateServiceDto value)
        {
            return Ok(await _service.Update(id, value));
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Service>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
