using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.EmployeeType;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services;

public class EmployeeTypeService : IEmployeeTypeService
{
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;
        
        public EmployeeTypeService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<EmployeeType>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<EmployeeType>>
            {
                Data = await _context.EmployeeTypes.ToListAsync()
            };
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<IEnumerable<EmployeeType>>> GetNotDeleted()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<EmployeeType>>
            {
                Data = await _context.EmployeeTypes
                    .Where(x => x.IsDeleted == false)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeType>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<EmployeeType>();
            serviceResponse.Data = await _context.EmployeeTypes.FirstOrDefaultAsync(x => x.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeType>> Create(UpdateEmployeeTypeDto dto)
        {
            var serviceResponse = new ServiceResponse<EmployeeType>();
            if (await _context.EmployeeTypes.AnyAsync(x => x.Type == dto.Type))
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            var newType = _mapper.Map<EmployeeType>(dto);

            _context.EmployeeTypes.Add(newType);
            await _context.SaveChangesAsync();
                        
            serviceResponse.Data = newType;
            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeType>> Update(Guid id, UpdateEmployeeTypeDto updatedData)
        {
            var serviceResponse = new ServiceResponse<EmployeeType>();

            var employeeType = await _context.EmployeeTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (employeeType == null) 
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            _mapper.Map(updatedData, employeeType);
            await _context.SaveChangesAsync();

            serviceResponse.Data = employeeType;

            return serviceResponse;
            
        }

        public async Task<ServiceResponse<EmployeeType>> Delete(Guid id)
        {
            var serviceResponse = await GetById(id);
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No Employee type found";
                serviceResponse.Success = false;
                return serviceResponse;
            };

            var employeeType = serviceResponse.Data;
            employeeType.IsDeleted = true;
            _context.EmployeeTypes.Update(employeeType);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }
}