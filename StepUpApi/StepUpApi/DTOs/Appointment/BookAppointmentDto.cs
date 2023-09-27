using StepUpApi.Models;

namespace StepUpApi.DTOs.Appointment
{
    public class BookAppointmentDto
    {
        public Customer? Customer { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public ICollection<Models.ExaminationType> ExaminationTypes { get; set; } = new List<Models.ExaminationType>();
        public string Comment { get; set; } = string.Empty;
        public string PatientJobTitle { get; set; } = string.Empty;
        
    }
}
