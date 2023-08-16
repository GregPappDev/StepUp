using System.ComponentModel.DataAnnotations;

namespace StepUpApi.Models
{
    public class ContactPerson
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
