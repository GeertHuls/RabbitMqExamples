namespace EasyNetqMessages.Polymorphic;

public class PurchaseOrder : IPayment
{
    public string PoNumber { get; set; } = default!;
    public string CompanyName { get; set; } = default!;
    public int PaymentDayTerms { get; set; } = default!;

    // Interface implementation
    public decimal Amount { get; set; }
}