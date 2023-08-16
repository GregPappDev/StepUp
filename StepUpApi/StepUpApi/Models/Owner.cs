using System.ComponentModel.DataAnnotations;

namespace StepUpApi.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
    }
}
