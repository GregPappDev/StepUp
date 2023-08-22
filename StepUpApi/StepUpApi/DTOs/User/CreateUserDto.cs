using System.ComponentModel.DataAnnotations;

namespace StepUpApi.DTOs.User
{
    public class CreateUserDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
