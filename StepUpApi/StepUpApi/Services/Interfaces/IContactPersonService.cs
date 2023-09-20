using StepUpApi.DTOs.ContactPerson;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IContactPersonService
    {
        Task<ServiceResponse<IEnumerable<ContactPerson>>> GetAll();
        Task<ServiceResponse<IEnumerable<ContactPerson>>> GetNotDeleted();
        Task<ServiceResponse<ContactPerson>> GetById(Guid id);
        Task<ServiceResponse<ContactPerson>> Create(UpdateContactPersonDto dto);
        Task<ServiceResponse<ContactPerson>> Update(Guid id, UpdateContactPersonDto updatedData);
        Task<ServiceResponse<ContactPerson>> Delete(Guid id);

    }
}
