using StepUpApi.DTOs.Role;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IRoleService
    {
        Task<ServiceResponse<IEnumerable<Role>>> GetAll();
        Task<ServiceResponse<IEnumerable<Role>>> GetNotDeleted();
        Task<ServiceResponse<Role>> GetById(Guid id);
        Task<ServiceResponse<Role>> Create(UpdateRoleDto dto);
        Task<ServiceResponse<Role>> Update(Guid id, UpdateRoleDto updatedData);
        Task<ServiceResponse<Role>> Delete(Guid id);
    }
}
