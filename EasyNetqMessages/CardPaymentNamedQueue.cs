using EasyNetQ;

namespace EasyNetqMessages;

[Queue("CardPaymentQueue", ExchangeName = "CardPaymentExchange")]
public class CardPaymentNamedQueue
{
    public string CardNumber { get; set; } = default!;
    public string CardHolderName { get; set; } = default!;
    public string ExpiryDate { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
}