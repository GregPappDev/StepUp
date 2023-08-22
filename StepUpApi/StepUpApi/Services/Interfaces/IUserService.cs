using StepUpApi.DTOs.User;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<User>>> GetAll();
        Task<ServiceResponse<User>> RegisterUser(CreateUserDto userDto);
    }
}