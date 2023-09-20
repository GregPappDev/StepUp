using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.Location;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ISurgeryService _service;

        public LocationController(ISurgeryService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Surgery>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Surgery>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Surgery>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Surgery>>> Create([FromBody] UpdateSurgeryDto type)
        {
            return Ok(await _service.Create(type));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Surgery>>> Put(Guid id, [FromBody] UpdateSurgeryDto value)
        {
            return Ok(await _service.Update(id, value));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Surgery>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
