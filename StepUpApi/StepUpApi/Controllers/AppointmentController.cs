using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.Appointment;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<NotAttendedDto>>> GetNotAttended()
        {
            return Ok(await _service.GetNotAttended());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Appointment>>> Create([FromBody] CreateAppointmentDto dto)
        {
            return Ok(await _service.Create(dto));
        }
    }
}
