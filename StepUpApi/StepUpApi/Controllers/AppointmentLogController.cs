using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.AppointmentLog;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentLogController : ControllerBase
    {
        private readonly IAppointmentLogService _service;

        public AppointmentLogController(IAppointmentLogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<AppointmentLog>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AppointmentLog>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AppointmentLog>>> Create([FromBody] CreateAppointmentLogDto dto)
        {
            return Ok(await _service.Create(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<AppointmentLog>>> Put(Guid id, [FromBody] UpdateAppointmentLogDto value)
        {
            return Ok(await _service.Update(id, value));
        }
    }
}
