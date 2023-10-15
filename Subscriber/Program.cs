using EasyNetQ;
using EasyNetqMessages;
using static EasyNetqMessages.Constants;

internal class Program
{
    private static void Main(string[] args)
    {
        using var bus = RabbitHutch.CreateBus(RabbitMqConnectionString);
        bus.PubSub.Subscribe<CardPaymentRequestMessage>("cardPayment", HandleCardPaymentMessage);

        Console.WriteLine("Listening for messages. Hit <return> to quit.");
        Console.ReadLine();
    }

    static void HandleCardPaymentMessage(CardPaymentRequestMessage paymentMessage)
    {
        Console.WriteLine("Payment = <" +
                          paymentMessage.CardNumber + ", " +
                          paymentMessage.CardHolderName + ", " +
                          paymentMessage.ExpiryDate + ", " +
                          paymentMessage.Amount + ">");
    }
}