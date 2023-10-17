using EasyNetQ;
using EasyNetqMessages;
using static EasyNetqMessages.Constants;

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

var response = bus.Rpc.Request<CardPaymentRequestMessage, CardPaymentResponseMessage>(payment);
Console.WriteLine(response.AuthCode);

Console.WriteLine("Response received.");
