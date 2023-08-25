using System.ComponentModel.DataAnnotations;

namespace StepUpApi.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public Owner? Owner { get; set; }
    public string Details { get; set; } = string.Empty;
    public DateTime StartOfContract { get; set; }
    public bool ContractOnFile { get; set; }
    public bool Vip { get; set; }
    public Location? Location { get; set; }
    public ICollection<ContactPerson> ContactPersons { get; set; } = new List<ContactPerson>();
    public ICollection<ContactDetails> ContactDetailsCollection { get; set; } = new List<ContactDetails>();
    public int HeadCountA { get; set; }
    public int HeadCountB { get; set; }
    public int HeadCountC { get; set; }
    public int HeadCountD { get; set; }
    public string BillingInfo { get; set; } = string.Empty;
    public string InvoiceEmail { get; set; } = string.Empty;
    public string InvoiceIssuer { get; set; } = string.Empty;
    public int InvoicePeriod { get; set; }
    public int InvoiceAmount { get; set; }
    public int PaymentDeadline { get; set; }
    public ICollection<PeriodicInvoice> PeriodicInvoices { get; set; } = new List<PeriodicInvoice>();
    public ICollection<Service> Services { get; set; } = new List<Service>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public bool IsDeleted { get; set; } = false;
}