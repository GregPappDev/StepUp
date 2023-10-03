using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<EmployeeType>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }
    }
}
