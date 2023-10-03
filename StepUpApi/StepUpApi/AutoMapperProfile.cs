using AutoMapper;
using StepUpApi.DTOs.EmployeeType;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.DTOs.Location;
using StepUpApi.DTOs.Owner;
using StepUpApi.DTOs.PeriodicInvoice;
using StepUpApi.DTOs.Role;
using StepUpApi.DTOs.Service;
using StepUpApi.DTOs.ContactPerson;
using StepUpApi.Models;
using StepUpApi.DTOs.ContactDetails;
using StepUpApi.DTOs.AppointmentLog;
using StepUpApi.DTOs.Appointment;
using StepUpApi.DTOs.UserDto;

namespace StepUpApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UpdateExaminationTypeDto, ExaminationType>();
            CreateMap<UpdateRoleDto, Role>();
            CreateMap<CreatePeriodicInvoiceDto, PeriodicInvoice>();
            CreateMap<UpdateOwnerDto, Owner>();
            CreateMap<UpdateServiceDto, Service>();
            CreateMap<UpdateSurgeryDto, Surgery>();
            CreateMap<UpdateEmployeeTypeDto, EmployeeType>();
            CreateMap<UpdateContactPersonDto, ContactPerson>();
            CreateMap<UpdateContactDetailsDto, ContactDetails>();
            CreateMap<UpdateAppointmentLogDto, AppointmentLog>();
            CreateMap<CreateAppointmentLogDto, AppointmentLog>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<User, UserDto>();
        }
    }
}
