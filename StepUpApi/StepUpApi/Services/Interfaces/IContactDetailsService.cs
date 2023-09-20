using StepUpApi.DTOs.ContactDetails;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IContactDetailsService
    {
        Task<ServiceResponse<IEnumerable<ContactDetails>>> GetAll();
        Task<ServiceResponse<IEnumerable<ContactDetails>>> GetNotDeleted();
        Task<ServiceResponse<ContactDetails>> GetById(Guid id);
        Task<ServiceResponse<ContactDetails>> Create(UpdateContactDetailsDto dto);
        Task<ServiceResponse<ContactDetails>> Update(Guid id, UpdateContactDetailsDto updatedData);
        Task<ServiceResponse<ContactDetails>> Delete(Guid id);

    }
}
