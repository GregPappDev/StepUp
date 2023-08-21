using AutoMapper;
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
            serviceResponse.Data = _context.ExaminationTypes;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ExaminationType>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<ExaminationType>();
            serviceResponse.Data = _context.ExaminationTypes.FirstOrDefault(e => e.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<ExaminationType>> Create(UpdateExaminationTypeDto dtoType)
        {
            var serviceResponse = new ServiceResponse<ExaminationType>();
            if (_context.ExaminationTypes.Any(type => type.Type == dtoType.Type))
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            var newType = _mapper.Map<ExaminationType>(dtoType);

            _context.ExaminationTypes.Add(newType);
            _context.SaveChanges();
                        
            serviceResponse.Data = newType;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ExaminationType>> Update(UpdateExaminationTypeDto updatedData)
        {
            throw new NotImplementedException();
        }

        public async void Delete(Guid id)
        {
            var serviceResponse = await GetById(id);
            if (serviceResponse.Data == null) return;
            _context.ExaminationTypes.Remove(serviceResponse.Data);
            _context.SaveChanges();
        }
    }
}
