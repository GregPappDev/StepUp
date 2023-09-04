﻿using AutoMapper;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.DTOs.PeriodicInvoice;
using StepUpApi.DTOs.Role;
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
        }
    }
}
