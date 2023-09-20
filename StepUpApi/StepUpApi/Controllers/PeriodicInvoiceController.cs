using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.PeriodicInvoice;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodicInvoiceController : ControllerBase
    {
        private readonly IPeriodicInvoice _service;

        public PeriodicInvoiceController(IPeriodicInvoice service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<PeriodicInvoice>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<PeriodicInvoice>>>> GetUnbilled()
        {
            return Ok(await _service.GetUnbilled());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<PeriodicInvoice>>> Create([FromBody] CreatePeriodicInvoiceDto type)
        {
            return Ok(await _service.Create(type));
        }
        
    }
}
