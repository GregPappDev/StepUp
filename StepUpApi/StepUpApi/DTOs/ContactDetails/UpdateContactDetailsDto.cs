using StepUpApi.Models.Enums;
using StepUpApi.Models;
using System.Text.Json.Serialization;

namespace StepUpApi.DTOs.ContactDetails
{
    public class UpdateContactDetailsDto
    {
        public ContactType ContactType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public Customer? Customer { get; set; }
    }
}
