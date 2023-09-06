using System.ComponentModel.DataAnnotations;

namespace StepUpApi.DTOs.UserDto
{
    public class LoginUserDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
