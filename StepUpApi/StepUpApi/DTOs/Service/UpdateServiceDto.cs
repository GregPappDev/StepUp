using System.Text.Json.Serialization;
using StepUpApi.Models;

namespace StepUpApi.DTOs.Service;

public class UpdateServiceDto
{
    public string Name { get; set; } = string.Empty;
    public int Rate { get; set; }
    public bool IsCurrentRate { get; set; }
    [JsonIgnore]
    public Customer? Customer { get; set; }
}