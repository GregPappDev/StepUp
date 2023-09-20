using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.EmployeeType;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService _service;

        public EmployeeTypeController(IEmployeeTypeService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<EmployeeType>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<EmployeeType>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeType>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EmployeeType>>> Create([FromBody] UpdateEmployeeTypeDto type)
        {
            return Ok(await _service.Create(type));
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeType>>> Put(Guid id, [FromBody] UpdateEmployeeTypeDto value)
        {
            return Ok(await _service.Update(id, value));
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeType>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
