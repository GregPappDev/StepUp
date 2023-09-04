using StepUpApi.Models;

namespace StepUpApi.DTOs.PeriodicInvoice;

public class CreatePeriodicInvoiceDto
{
    public string Period { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int PaymentDeadline { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public Customer? Customer { get; set; }
}