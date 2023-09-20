using StepUpApi.DTOs.PeriodicInvoice;
using StepUpApi.Models;

namespace StepUpApi.Services.Interfaces;

public interface IPeriodicInvoice
{
    Task<ServiceResponse<IEnumerable<PeriodicInvoice>>> GetAll();
    Task<ServiceResponse<IEnumerable<PeriodicInvoice>>> GetUnbilled();
    Task<ServiceResponse<PeriodicInvoice>> Create(CreatePeriodicInvoiceDto dto);
}