using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepUpApi.Data;
using StepUpApi.DTOs.PeriodicInvoice;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;

namespace StepUpApi.Services;

public class PeriodicInvoiceService : IPeriodicInvoice
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;

    public PeriodicInvoiceService(IMapper mapper, ApiDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<ServiceResponse<IEnumerable<PeriodicInvoice>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<IEnumerable<PeriodicInvoice>>
        {
            Data = await _context.PeriodicInvoices
                .Include(x => x.Customer)
                .ToListAsync()
        };
        return serviceResponse;
    }

    public async Task<ServiceResponse<IEnumerable<PeriodicInvoice>>> GetUnbilled()
    {
        var serviceResponse = new ServiceResponse<IEnumerable<PeriodicInvoice>>
        {
            Data = await _context.PeriodicInvoices
                .Include(x => x.Customer)
                .Where(x => x.InvoiceNumber.Length < 1)
                .ToListAsync()
        };
        return serviceResponse;
    }

    public async Task<ServiceResponse<PeriodicInvoice>> Create(CreatePeriodicInvoiceDto dto)
    {
        var serviceResponse = new ServiceResponse<PeriodicInvoice>();
        if (await _context.PeriodicInvoices
                .AnyAsync(x => x.Period == dto.Period && x.Customer == dto.Customer))
        {
            serviceResponse.Data = null;
            return serviceResponse;
        }

        var periodicInvoice = _mapper.Map<PeriodicInvoice>(dto);

        _context.PeriodicInvoices.Add(periodicInvoice);
        await _context.SaveChangesAsync();
                        
        serviceResponse.Data = periodicInvoice;
        return serviceResponse;
    }
}