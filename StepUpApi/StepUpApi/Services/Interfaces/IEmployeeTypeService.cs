using StepUpApi.DTOs.EmployeeType;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces;

public interface IEmployeeTypeService
{
    Task<ServiceResponse<IEnumerable<EmployeeType>>> GetAll();
    Task<ServiceResponse<IEnumerable<EmployeeType>>> GetNotDeleted();
    Task<ServiceResponse<EmployeeType>> GetById(Guid id);
    Task<ServiceResponse<EmployeeType>> Create(UpdateEmployeeTypeDto dto);
    Task<ServiceResponse<EmployeeType>> Update(Guid id, UpdateEmployeeTypeDto updatedData);
    Task<ServiceResponse<EmployeeType>> Delete(Guid id);
}