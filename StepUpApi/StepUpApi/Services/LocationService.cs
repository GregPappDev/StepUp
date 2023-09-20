using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.Location;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public LocationService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<Location>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Location>>
            {
                Data = await _context.Locations
                    .Include(x => x.Customers)
                    .Include(x => x.Appointments)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<Location>>> GetNotDeleted()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Location>>
            {
                Data = await _context.Locations
                    .Where(x => x.IsDeleted == false)
                    .Include(x => x.Customers)
                    .Include(x => x.Appointments)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<Location>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<Location>();
            serviceResponse.Data = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Location>> Create(UpdateLocationDto dto)
        {
            var serviceResponse = new ServiceResponse<Location>();
            if (await _context.Locations.AnyAsync(x => x.Name == dto.Name))
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            var location = _mapper.Map<Location>(dto);

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            serviceResponse.Data = location;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Location>> Update(Guid id, UpdateLocationDto updatedData)
        {
            var serviceResponse = new ServiceResponse<Location>();

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

        public async Task<ServiceResponse<Location>> Delete(Guid id)
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
