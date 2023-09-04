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
        private readonly ILocationService _service;

        public LocationController(ILocationService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Location>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Location>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Location>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Location>>> Create([FromBody] UpdateLocationDto type)
        {
            return Ok(await _service.Create(type));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Location>>> Put(Guid id, [FromBody] UpdateLocationDto value)
        {
            return Ok(await _service.Update(id, value));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Location>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
