namespace EasyNetqMessages;

public class PurchaseOrderRequestMessage
{
    public string PoNumber { get; set; } = default!;
    public string CompanyName { get; set; } = default!;
    public int PaymentDayTerms { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
}