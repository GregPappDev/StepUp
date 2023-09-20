using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.Owner;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;

        public OwnerController(IOwnerService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Owner>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Owner>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Owner>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Owner>>> Create([FromBody] UpdateOwnerDto type)
        {
            return Ok(await _service.Create(type));
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Owner>>> Put(Guid id, [FromBody] UpdateOwnerDto value)
        {
            return Ok(await _service.Update(id, value));
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Owner>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
