using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ServiceResponse<IQueryable<Appointment>>> GetAll();
        Task<ServiceResponse<IQueryable<Appointment>>> GetNotDeleted();
        Task<ServiceResponse<Appointment>> GetById(Guid id);
        Task<ServiceResponse<Appointment>> Create(UpdateExaminationTypeDto dto);
        Task<ServiceResponse<Appointment>> Update(Guid id, UpdateExaminationTypeDto updatedData);
        Task<ServiceResponse<Appointment>> Delete(Guid id);
    }
}
