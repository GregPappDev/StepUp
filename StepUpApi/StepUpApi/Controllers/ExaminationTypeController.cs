using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StepUpApi.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationTypeController : ControllerBase
    {
        private readonly IExaminationTypeService _service;

        public ExaminationTypeController(IExaminationTypeService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ExaminationType>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ExaminationType>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ExaminationType>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ExaminationType>>> Create([FromBody] UpdateExaminationTypeDto type)
        {
            return Ok(await _service.Create(type));
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<ExaminationType>>> Put(Guid id, [FromBody] UpdateExaminationTypeDto value)
        {
            return Ok(await _service.Update(id, value));
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ExaminationType>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
