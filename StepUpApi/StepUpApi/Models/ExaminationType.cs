using System.ComponentModel.DataAnnotations;

namespace StepUpApi.Models;

public class ExaminationType
{
    public Guid Id { get; set; }
    [Required]
    public string Type { get; set; } = string.Empty;
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}