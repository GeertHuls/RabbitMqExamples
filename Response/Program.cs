using EasyNetQ;
using EasyNetqMessages;
using static EasyNetqMessages.Constants;

internal class Program
{
    private static void Main(string[] args)
    {
        using var bus = RabbitHutch.CreateBus(RabbitMqConnectionString);
        bus.Rpc.Respond<CardPaymentRequestMessage, CardPaymentResponseMessage>(Responder);

        Console.WriteLine("Listening for messages. Hit <return> to quit.");
        Console.ReadLine();
    }

    static CardPaymentResponseMessage Responder(CardPaymentRequestMessage request)
    {
        return new CardPaymentResponseMessage { AuthCode = "1234" };
    }
}