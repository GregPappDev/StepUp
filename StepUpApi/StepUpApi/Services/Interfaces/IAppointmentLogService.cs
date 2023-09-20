using StepUpApi.DTOs.AppointmentLog;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IAppointmentLogService
    {
        Task<ServiceResponse<IEnumerable<AppointmentLog>>> GetAll();
        Task<ServiceResponse<AppointmentLog>> GetById(Guid id);
        Task<ServiceResponse<AppointmentLog>> Create(CreateAppointmentLogDto dto);
        Task<ServiceResponse<AppointmentLog>> Update(Guid id, UpdateAppointmentLogDto updatedData);
    }
}
