using StepUpApi.Data;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class ExaminationTypeService : IExaminationTypeService
    {
        private readonly ApiDbContext _context;
        
        public ExaminationTypeService(ApiDbContext context)
        {
            _context = context;
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

        public async Task<ServiceResponse<ExaminationType>> Create(ExaminationType item)
        {
            var serviceResponse = new ServiceResponse<ExaminationType>();
            if (_context.ExaminationTypes.Any(type => type.Type == item.Type))
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }
            _context.ExaminationTypes.Add(item);
            _context.SaveChanges();
                        
            serviceResponse.Data = item;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ExaminationType>> Update(ExaminationType updatedData)
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
