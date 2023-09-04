using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.ExaminationType;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class ExaminationTypeService : IExaminationTypeService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;
        
        public ExaminationTypeService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<ExaminationType>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<ExaminationType>>();
            serviceResponse.Data = await _context.ExaminationTypes.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<ExaminationType>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<ExaminationType>();
            serviceResponse.Data = await _context.ExaminationTypes.FirstOrDefaultAsync(e => e.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<ExaminationType>> Create(UpdateExaminationTypeDto dtoType)
        {
            var serviceResponse = new ServiceResponse<ExaminationType>();
            if (await _context.ExaminationTypes.AnyAsync(type => type.Type == dtoType.Type))
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            var newType = _mapper.Map<ExaminationType>(dtoType);

            _context.ExaminationTypes.Add(newType);
            await _context.SaveChangesAsync();
                        
            serviceResponse.Data = newType;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ExaminationType>> Update(Guid id, UpdateExaminationTypeDto updatedData)
        {
            var serviceResponse = new ServiceResponse<ExaminationType>();

            var examinationType = await _context.ExaminationTypes.FirstOrDefaultAsync(e => e.Id == id);
            if (examinationType == null) 
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            _mapper.Map(updatedData, examinationType);
            await _context.SaveChangesAsync();

            serviceResponse.Data = examinationType;

            return serviceResponse;
            
        }

        public async Task<ServiceResponse<ExaminationType>> Delete(Guid id)
        {
            var serviceResponse = await GetById(id);
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No examination type found";
                serviceResponse.Success = false;
                return serviceResponse;
            };

            var examinationType = serviceResponse.Data;
            examinationType.IsDeleted = true;
            _context.ExaminationTypes.Update(examinationType);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }
    }
}
