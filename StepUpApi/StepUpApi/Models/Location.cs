using System.ComponentModel.DataAnnotations;

namespace StepUpApi.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
