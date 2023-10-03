using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.Location;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class SurgeryService : ISurgeryService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public SurgeryService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<Surgery>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Surgery>>
            {
                Data = await _context.Locations
                    .Include(x => x.Customers)
                    .Include(x => x.Appointments)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<Surgery>>> GetNotDeleted()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Surgery>>
            {
                Data = await _context.Locations
                    .Where(x => x.IsDeleted == false)
                    .Include(x => x.Customers)
                    .Include(x => x.Appointments)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<Surgery>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<Surgery>();
            serviceResponse.Data = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Surgery>> Create(UpdateSurgeryDto dto)
        {
            var serviceResponse = new ServiceResponse<Surgery>();
            if (await _context.Locations.AnyAsync(x => x.Name == dto.Name))
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            var location = _mapper.Map<Surgery>(dto);

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            serviceResponse.Data = location;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Surgery>> Update(Guid id, UpdateSurgeryDto updatedData)
        {
            var serviceResponse = new ServiceResponse<Surgery>();

            var location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            if (location == null)
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            _mapper.Map(updatedData, location);
            await _context.SaveChangesAsync();

            serviceResponse.Data = location;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Surgery>> Delete(Guid id)
        {
            var serviceResponse = await GetById(id);
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No location found";
                serviceResponse.Success = false;
                return serviceResponse;
            };

            var location = serviceResponse.Data;
            location.IsDeleted = true;
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }

    }
}
