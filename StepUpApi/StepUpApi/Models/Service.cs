using System.Text.Json.Serialization;

namespace StepUpApi.Models;

public class Service
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Rate { get; set; }
    public bool IsCurrentRate { get; set; }
    [JsonIgnore]
    public Customer? Customer { get; set; }
    public bool IsDeleted { get; set; } = false;
}