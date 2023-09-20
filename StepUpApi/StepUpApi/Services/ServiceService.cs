using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.Service;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services;

public class ServiceService : IServiceService
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;
        
    public ServiceService(ApiDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<ServiceResponse<IEnumerable<Service>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<IEnumerable<Service>>
        {
            Data = await _context.Services
                .Include(x => x.Customer)
                .ToListAsync()
        };
        return serviceResponse;
    }

    public async Task<ServiceResponse<IEnumerable<Service>>> GetNotDeleted()
    {
        var serviceResponse = new ServiceResponse<IEnumerable<Service>>
        {
            Data = await _context.Services
                .Include(x => x.Customer)
                .Where(x => x.IsDeleted == false)
                .ToListAsync()
        };
        return serviceResponse;
    }

    public async Task<ServiceResponse<Service>> GetById(Guid id)
    {
        var serviceResponse = new ServiceResponse<Service>();
        serviceResponse.Data = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
        return serviceResponse;
    }

    public async Task<ServiceResponse<Service>> Create(UpdateServiceDto dto)
    {
        var serviceResponse = new ServiceResponse<Service>();
        if (await _context.Services
                .AnyAsync(x => x.Name == dto.Name && x.Customer == dto.Customer))
        {
            serviceResponse.Data = null;
            return serviceResponse;
        }

        var service = _mapper.Map<Service>(dto);

        _context.Services.Add(service);
        await _context.SaveChangesAsync();
                        
        serviceResponse.Data = service;
        return serviceResponse;
    }

    public async Task<ServiceResponse<Service>> Update(Guid id, UpdateServiceDto updatedData)
    {
        var serviceResponse = new ServiceResponse<Service>();

        var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
        if (service == null) 
        {
            serviceResponse.Data = null;
            return serviceResponse;
        }

        _mapper.Map(updatedData, service);
        await _context.SaveChangesAsync();

        serviceResponse.Data = service;

        return serviceResponse;
    }

    public async Task<ServiceResponse<Service>> Delete(Guid id)
    {
        var serviceResponse = await GetById(id);
        if (serviceResponse.Data == null)
        {
            serviceResponse.Message = "No service found";
            serviceResponse.Success = false;
            return serviceResponse;
        };

        var service = serviceResponse.Data;
        service.IsDeleted = true;
        _context.Services.Update(service);
        await _context.SaveChangesAsync();

        return serviceResponse;
    }
}