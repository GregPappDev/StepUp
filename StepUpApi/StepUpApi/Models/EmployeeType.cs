namespace StepUpApi.Models;

public class EmployeeType
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
    public bool IsDeleted { get; set; } = false;
}