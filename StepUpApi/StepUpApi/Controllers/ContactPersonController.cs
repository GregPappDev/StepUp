using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepUpApi.DTOs.ContactPerson;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly IContactPersonService _service;

        public ContactPersonController(IContactPersonService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ContactPerson>>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ContactPerson>>>> GetNotDeleted()
        {
            return Ok(await _service.GetNotDeleted());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactPerson>>> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ContactPerson>>> Create([FromBody] UpdateContactPersonDto type)
        {
            return Ok(await _service.Create(type));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactPerson>>> Put(Guid id, [FromBody] UpdateContactPersonDto value)
        {
            return Ok(await _service.Update(id, value));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactPerson>>> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
