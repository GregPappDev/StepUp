using StepUpApi.DTOs.Owner;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces;

public interface IOwnerService
{
    Task<ServiceResponse<IEnumerable<Owner>>> GetAll();
    Task<ServiceResponse<IEnumerable<Owner>>> GetNotDeleted();
    Task<ServiceResponse<Owner>> GetById(Guid id);
    Task<ServiceResponse<Owner>> Create(UpdateOwnerDto dto);
    Task<ServiceResponse<Owner>> Update(Guid id, UpdateOwnerDto updatedData);
    Task<ServiceResponse<Owner>> Delete(Guid id);
}