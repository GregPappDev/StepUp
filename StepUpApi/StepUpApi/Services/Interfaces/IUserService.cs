using StepUpApi.DTOs.User;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<User>>> GetAll();
        Task<ServiceResponse<IEnumerable<User>>> GetNotDeleted();
        Task<ServiceResponse<User>> RegisterUser(CreateUserDto userDto);
        Task<ServiceResponse<string>> Login(LoginUserDto userDto);
        Task<ServiceResponse<User>> GetById(Guid id);
        Task<ServiceResponse<User>> Delete(Guid id);

    }
}