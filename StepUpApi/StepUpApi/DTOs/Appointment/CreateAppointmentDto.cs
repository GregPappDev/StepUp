using StepUpApi.Models;
using StepUpApi.DTOs.UserDto;

using System.ComponentModel.DataAnnotations;


namespace StepUpApi.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        public DateTime DateTime { get; set; }
        
        public Guid? SurgeryId { get; set; }
        public ICollection<Guid> UserIds { get; set; } = new List<Guid>();
    }
}
