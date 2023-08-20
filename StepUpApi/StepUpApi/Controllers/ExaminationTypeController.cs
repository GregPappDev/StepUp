using Microsoft.AspNetCore.Mvc;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StepUpApi.Controllers
{
    
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
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_service.GetById(id));
        }

        
        [HttpPost]
        public void Create([FromBody] ExaminationType type)
        {
            _service.Create(type);
        }

        // PUT api/<ExaminationTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExaminationTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
