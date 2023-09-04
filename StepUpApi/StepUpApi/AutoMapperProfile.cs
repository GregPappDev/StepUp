using AutoMapper;
using StepUpApi.DTOs.EmployeeType;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.DTOs.Location;
using StepUpApi.DTOs.Owner;
using StepUpApi.DTOs.PeriodicInvoice;
using StepUpApi.DTOs.Role;
using StepUpApi.DTOs.Service;
using StepUpApi.Models;

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
            CreateMap<UpdateLocationDto, Location>();
            CreateMap<UpdateEmployeeTypeDto, EmployeeType>();
        }
    }
}
