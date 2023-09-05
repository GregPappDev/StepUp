using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.ContactDetails;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly IContactDetailsService _service;

        public ContactDetailsController(IContactDetailsService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ContactDetails>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ContactDetails>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactDetails>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ContactDetails>>> Create([FromBody] UpdateContactDetailsDto type)
        {
            return Ok(await _service.Create(type));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactDetails>>> Put(Guid id, [FromBody] UpdateContactDetailsDto value)
        {
            return Ok(await _service.Update(id, value));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactDetails>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
