using EasyNetQ;
using EasyNetqMessages.Polymorphic;
using static EasyNetqMessages.Constants;

internal class Program
{
    private static void Main(string[] args)
    {
        using var bus = RabbitHutch.CreateBus(RabbitMqConnectionString);
        bus.PubSub.Subscribe<IPayment>("purchaseorders", Handler, x => x.WithTopic("payment.purchaseorder"));

        Console.WriteLine("Listening for (payment.purchaseorer) messages. Hit <return> to quit.");
        Console.ReadLine();
    }

    public static void Handler(IPayment payment)
    {
        var purchaseOrder = payment as PurchaseOrder;

        if (purchaseOrder != null)
        {
            Console.WriteLine("Processing Purchase Order = <" +
                              purchaseOrder.CompanyName + ", " +
                              purchaseOrder.PoNumber + ", " +
                              purchaseOrder.PaymentDayTerms + ", " +
                              purchaseOrder.Amount + ">");
        }
    }
}