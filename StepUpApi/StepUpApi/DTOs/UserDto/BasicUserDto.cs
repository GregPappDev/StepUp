namespace StepUpApi.DTOs.UserDto
{
    public class BasicUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Models.EmployeeType? EmployeeType { get; set; }
    }
}
