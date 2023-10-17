using EasyNetQ;
using EasyNetqMessages;
using static EasyNetqMessages.Constants;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var payment = new CardPaymentRequestMessage
        {
            CardNumber = "1234123412341234",
            CardHolderName = "Mr F Bloggs",
            ExpiryDate = "12/12",
            Amount = 99.00m
        };

        using var bus = RabbitHutch.CreateBus(RabbitMqConnectionString);
        Console.WriteLine("Publishing messages with request and response.");
        Console.WriteLine();

        var response = await bus.Rpc.RequestAsync<CardPaymentRequestMessage, CardPaymentResponseMessage>(payment);

        Console.WriteLine("Got response: '{0}'", response.AuthCode);
        Console.ReadLine();
    }
}