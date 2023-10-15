namespace EasyNetqMessages;

public class CardPaymentRequestMessage
{
    public string CardNumber { get; set; } = default!;
    public string CardHolderName { get; set; } = default!;
    public string ExpiryDate { get; set; } = default!;
    public decimal Amount { get; set; }
}