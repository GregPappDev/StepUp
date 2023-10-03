using StepUpApi.Models;
using System.ComponentModel.DataAnnotations;


namespace StepUpApi.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        public DateTime DateTime { get; set; }
        
        public Surgery? Surgery { get; set; }
        public ICollection<User> PersonnelAttending { get; set; } = new List<User>();
    }
}
