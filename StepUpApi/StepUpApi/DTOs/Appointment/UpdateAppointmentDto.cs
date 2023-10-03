using StepUpApi.Models.Enums;
using StepUpApi.Models;

namespace StepUpApi.DTOs.Appointment
{
    public class UpdateAppointmentDto
    {
        public DateTime DateTime { get; set; }
        public Surgery? Surgery { get; set; }
        public Customer? Customer { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public ICollection<Models.ExaminationType> ExaminationTypes { get; set; } = new List<Models.ExaminationType>();
        public string Comment { get; set; } = string.Empty;
        public DateTime PatientDateOfBirth { get; set; }
        public string PatientJobTitle { get; set; } = string.Empty;
        public char PatientCategory { get; set; }
        public bool HasAttended { get; set; }
        public ResultType Result { get; set; }
        public DateTime NextExamination { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
    }
}
