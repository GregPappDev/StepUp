using StepUpApi.DTOs.Location;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface ILocationService
    {
        Task<ServiceResponse<IEnumerable<Location>>> GetAll();
        Task<ServiceResponse<IEnumerable<Location>>> GetNotDeleted();
        Task<ServiceResponse<Location>> GetById(Guid id);
        Task<ServiceResponse<Location>> Create(UpdateLocationDto dto);
        Task<ServiceResponse<Location>> Update(Guid id, UpdateLocationDto updatedData);
        Task<ServiceResponse<Location>> Delete(Guid id);
    }
}
