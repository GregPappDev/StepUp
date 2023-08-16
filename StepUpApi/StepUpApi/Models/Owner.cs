using System.ComponentModel.DataAnnotations;

namespace StepUpApi.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required] 
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
