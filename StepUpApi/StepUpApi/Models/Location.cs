using System.ComponentModel.DataAnnotations;

namespace StepUpApi.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
