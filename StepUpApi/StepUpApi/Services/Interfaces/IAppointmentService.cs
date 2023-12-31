﻿using StepUpApi.DTOs.Appointment;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAll();
        Task<ServiceResponse<IEnumerable<Appointment>>> GetNotDeleted();
        Task<ServiceResponse<Appointment>> GetById(Guid id);
        Task<ServiceResponse<Appointment>> Create(CreateAppointmentDto dto);
        Task<ServiceResponse<Appointment>> Update(Guid id, UpdateExaminationTypeDto updatedData);
        Task<ServiceResponse<Appointment>> Delete(Guid id);
        Task<ServiceResponse<IEnumerable<Appointment>>> BookAppointment(List<BookAppointmentDto> dto);
        Task<IEnumerable<NotAttendedDto>> GetNotAttended();
    }
}
