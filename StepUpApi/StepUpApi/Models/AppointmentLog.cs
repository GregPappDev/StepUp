namespace StepUpApi.Models;

public class AppointmentLog
{
    public Guid Id { get; set; }
    public DateTime AccessTime { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public Appointment? Appointment { get; set; }
    public bool IsDeleted { get; set; } = false;
}