using StepUpApi.DTOs;
using StepUpApi.DTOs.Appointment;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<ServiceResponse<IEnumerable<Customer>>> GetNotDeleted();
        Task<ServiceResponse<Customer>> GetById(Guid id);
        Task<ServiceResponse<Customer>> Create(CreateCustomerDto dto);
        Task<ServiceResponse<Customer>> Update(Guid id, CreateCustomerDto updatedData);
        Task<ServiceResponse<Customer>> Delete(Guid id);
        
    }
}
