using AutoMapper;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;

namespace StepUpApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UpdateExaminationTypeDto, ExaminationType>();
        }
    }
}
