using System.ComponentModel.DataAnnotations;
using StepUpApi.Models.Enums;

namespace StepUpApi.Models;

public class ContactDetails
{
    public Guid Id { get; set; }
    [Required]
    public ContactType ContactType { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required] 
    public string Address { get; set; } = string.Empty;
    [Required] 
    public string City { get; set; } = string.Empty;
    [Required] 
    public string ZipCode { get; set; } = string.Empty;
    [Required] 
    public string Country { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Customer? Customer { get; set; }
}