using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StepUpApi.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        [JsonIgnore]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public bool IsDeleted { get; set; } = false;

    }
}
