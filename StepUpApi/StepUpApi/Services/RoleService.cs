using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.Role;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<Role>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Role>>
            {
                Data = await _context.Roles.ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<Role>>> GetNotDeleted()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Role>>
            {
                Data = await _context.Roles
                    .Where(x => x.IsDeleted == false)
                    .ToListAsync()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<Role>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<Role>();
            serviceResponse.Data = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Role>> Create(UpdateRoleDto dto)
        {
            var serviceResponse = new ServiceResponse<Role>();
            if (await _context.Roles.AnyAsync(x => x.Type == dto.Type))
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            var newRole = _mapper.Map<Role>(dto);

            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();

            serviceResponse.Data = newRole;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Role>> Update(Guid id, UpdateRoleDto updatedData)
        {
            var serviceResponse = new ServiceResponse<Role>();

            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null)
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            _mapper.Map(updatedData, role);
            await _context.SaveChangesAsync();

            serviceResponse.Data = role;

            return serviceResponse; 
        }

        public async Task<ServiceResponse<Role>> Delete(Guid id)
        {
            var serviceResponse = await GetById(id);
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No examination type found";
                serviceResponse.Success = false;
                return serviceResponse;
            };

            var role = serviceResponse.Data;
            role.IsDeleted = true;
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }

    }
}
