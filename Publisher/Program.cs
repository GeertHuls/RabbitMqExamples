using EasyNetQ;
using EasyNetqMessages;
using static EasyNetqMessages.Constants;

var payment1 = new CardPaymentRequestMessage
{
    CardNumber = "1234123412341234",
    CardHolderName = "Mr F Bloggs",
    ExpiryDate = "12/12",
    Amount = 99.00m
};

var payment2 = new CardPaymentRequestMessage
{
    CardNumber = "3456345634563456",
    CardHolderName = "Mr S Claws",
    ExpiryDate = "03/11",
    Amount = 15.00m
};

var payment3 = new CardPaymentRequestMessage
{
    CardNumber = "6789678967896789",
    CardHolderName = "Mrs E Curry",
    ExpiryDate = "01/03",
    Amount = 1250.24m
};

var payment4 = new CardPaymentRequestMessage
{
    CardNumber = "9991999299939994",
    CardHolderName = "Mrs D Parton",
    ExpiryDate = "04/07",
    Amount = 34.87m
};

using var bus = RabbitHutch.CreateBus(RabbitMqConnectionString);
Console.WriteLine("Publishing messages with publish and subscribe.");
Console.WriteLine();
Thread.Sleep(2000);

bus.PubSub.Publish(payment1);
bus.PubSub.Publish(payment2);
bus.PubSub.Publish(payment3);
bus.PubSub.Publish(payment4);
