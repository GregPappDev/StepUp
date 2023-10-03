using StepUpApi.Models;

namespace StepUpApi.DTOs
{
    public class CreateCustomerDto
    {
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public Models.Owner? Owner { get; set; }
        public string Details { get; set; } = string.Empty;
        public DateTime StartOfContract { get; set; }
        public bool ContractOnFile { get; set; }
        public bool Vip { get; set; }
        public Surgery? Location { get; set; }
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
    }
}
