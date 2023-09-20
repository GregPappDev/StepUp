using StepUpApi.DTOs.Service;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces;

public interface IServiceService
{
    Task<ServiceResponse<IEnumerable<Service>>> GetAll();
    Task<ServiceResponse<IEnumerable<Service>>> GetNotDeleted();
    Task<ServiceResponse<Service>> GetById(Guid id);
    Task<ServiceResponse<Service>> Create(UpdateServiceDto dto);
    Task<ServiceResponse<Service>> Update(Guid id, UpdateServiceDto updatedData);
    Task<ServiceResponse<Service>> Delete(Guid id);
}