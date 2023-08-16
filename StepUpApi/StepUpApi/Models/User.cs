using System.ComponentModel.DataAnnotations;

namespace StepUpApi.Models;

public class User
{
    public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public EmployeeType? EmployeeType { get; set; }
    [Required]
    public ICollection<Role> Collection { get; set; } = new List<Role>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<AppointmentLog> AppointmentLogs { get; set; } = new List<AppointmentLog>();
}