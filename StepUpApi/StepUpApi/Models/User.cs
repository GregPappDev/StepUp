using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StepUpApi.Models;

public class User
{
    public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public byte[] PasswordHash { get; set; }
    [Required]
    public byte[] PasswordSalt { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public EmployeeType? EmployeeType { get; set; }
    [JsonIgnore]
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    [JsonIgnore]
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    [JsonIgnore]
    public ICollection<AppointmentLog> AppointmentLogs { get; set; } = new List<AppointmentLog>();
}