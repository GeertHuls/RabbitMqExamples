using EasyNetQ;
using EasyNetqMessages.Polymorphic;
using static EasyNetqMessages.Constants;

internal class Program
{
    private static void Main(string[] args)
    {
        using var bus = RabbitHutch.CreateBus(RabbitMqConnectionString);
        bus.PubSub.Subscribe<IPayment>("cards", Handler, x => x.WithTopic("payment.cardpayment"));

        Console.WriteLine("Listening for (payment.cardpayment) messages. Hit <return> to quit.");
        Console.ReadLine();
    }

    public static void Handler(IPayment payment)
    {
        var cardPayment = payment as CardPayment;

        if (cardPayment != null)
        {
            Console.WriteLine("Processing Card Payment = <" +
                              cardPayment.CardNumber + ", " +
                              cardPayment.CardHolderName + ", " +
                              cardPayment.ExpiryDate + ", " +
                              cardPayment.Amount + ">");
        }
    }
}