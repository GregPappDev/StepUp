using StepUpApi.DTOs;

namespace StepUpApi.DTOs.Appointment
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime? DateTime { get; set; }
        public Guid? SurgeryId { get; set; }
        public string SurgeryName { get; set; } = string.Empty;
        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public ICollection<Models.ExaminationType> ExaminationTypes { get; set; } = new List<Models.ExaminationType>();
        public string Comment { get; set; } = string.Empty;
        public ICollection<UserDto.UserDto> PersonnelAttending { get; set; } = new List<UserDto.UserDto>();
    }
}
