using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.Owner;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services;

public class OwnerService : IOwnerService
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;
        
    public OwnerService(ApiDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<ServiceResponse<IEnumerable<Owner>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<IEnumerable<Owner>>
        {
            Data = await _context.Owners
                .Include(x => x.Customers)
                .ToListAsync()
        };
        return serviceResponse;
    }

    public async Task<ServiceResponse<IEnumerable<Owner>>> GetNotDeleted()
    {
        var serviceResponse = new ServiceResponse<IEnumerable<Owner>>
        {
            Data = await _context.Owners
                .Include(x => x.Customers)
                .Where(x=> x.IsDeleted == false)
                .ToListAsync()
        };
        return serviceResponse;
    }

    public async Task<ServiceResponse<Owner>> GetById(Guid id)
    {
        var serviceResponse = new ServiceResponse<Owner>();
        serviceResponse.Data = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
        return serviceResponse;
    }

    public async Task<ServiceResponse<Owner>> Create(UpdateOwnerDto dto)
    {
        var serviceResponse = new ServiceResponse<Owner>();
        if (await _context.Owners.AnyAsync(x => x.Name == dto.Name))
        {
            serviceResponse.Data = null;
            return serviceResponse;
        }

        var owner = _mapper.Map<Owner>(dto);

        _context.Owners.Add(owner);
        await _context.SaveChangesAsync();
                        
        serviceResponse.Data = owner;
        return serviceResponse;
    }

    public async Task<ServiceResponse<Owner>> Update(Guid id, UpdateOwnerDto updatedData)
    {
        var serviceResponse = new ServiceResponse<Owner>();

        var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
        if (owner == null) 
        {
            serviceResponse.Data = null;
            return serviceResponse;
        }

        _mapper.Map(updatedData, owner);
        await _context.SaveChangesAsync();

        serviceResponse.Data = owner;

        return serviceResponse;
    }

    public async Task<ServiceResponse<Owner>> Delete(Guid id)
    {
        var serviceResponse = await GetById(id);
        if (serviceResponse.Data == null)
        {
            serviceResponse.Message = "No owner found";
            serviceResponse.Success = false;
            return serviceResponse;
        };

        var owner = serviceResponse.Data;
        owner.IsDeleted = true;
        _context.Owners.Update(owner);
        await _context.SaveChangesAsync();

        return serviceResponse;
    }
}