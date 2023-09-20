namespace StepUpApi.DTOs.ContactPerson
{
    public class UpdateContactPersonDto
    {
        public string Name { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
