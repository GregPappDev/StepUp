using System.Text.Json.Serialization;

namespace StepUpApi.Models;

public class Role
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<User> Users { get; set; } = new List<User>(); 
    public bool IsDeleted { get; set; } = false;

}