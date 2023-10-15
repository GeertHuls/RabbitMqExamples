namespace EasyNetqMessages.Polymorphic;

public class CardPayment : IPayment
{
    public string CardNumber { get; set; } = default!;
    public string CardHolderName { get; set; } = default!;
    public string ExpiryDate { get; set; } = default!;

    // Interface implementation
    public decimal Amount { get; set; }
}
