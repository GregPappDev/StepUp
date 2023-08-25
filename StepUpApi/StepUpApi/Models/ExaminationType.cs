using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StepUpApi.Models;

public class ExaminationType
{
    public Guid Id { get; set; }
    [Required]
    public string Type { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public bool IsDeleted { get; set; } = false;
}