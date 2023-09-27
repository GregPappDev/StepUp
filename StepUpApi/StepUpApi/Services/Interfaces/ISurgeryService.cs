using StepUpApi.DTOs.Location;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface ISurgeryService
    {
        Task<ServiceResponse<IEnumerable<Surgery>>> GetAll();
        Task<ServiceResponse<IEnumerable<Surgery>>> GetNotDeleted();
        Task<ServiceResponse<Surgery>> GetById(Guid id);
        Task<ServiceResponse<Surgery>> Create(UpdateSurgeryDto dto);
        Task<ServiceResponse<Surgery>> Update(Guid id, UpdateSurgeryDto updatedData);
        Task<ServiceResponse<Surgery>> Delete(Guid id);
    }
}
