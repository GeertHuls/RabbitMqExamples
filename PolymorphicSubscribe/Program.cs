﻿using EasyNetQ;
using EasyNetqMessages.Polymorphic;
using static EasyNetqMessages.Constants;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var bus = RabbitHutch.CreateBus(RabbitMqConnectionString))
        {
            bus.PubSub.Subscribe<IPayment>("payments", message => HandleMessage(message));

            Console.WriteLine("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();
        }
    }

    private static void HandleMessage(IPayment message)
    {
        var cardPayment = message as CardPayment;
        var purchaseOrder = message as PurchaseOrder;

        if (cardPayment != null)
        {
            Console.WriteLine("Card Payment = <" +
                              cardPayment.CardNumber + ", " +
                              cardPayment.CardHolderName + ", " +
                              cardPayment.ExpiryDate + ", " +
                              cardPayment.Amount + ">");
        }
        else if (purchaseOrder != null)
        {
            Console.WriteLine("Purchase Order = <" +
                              purchaseOrder.CompanyName + ", " +
                              purchaseOrder.PoNumber + ", " +
                              purchaseOrder.PaymentDayTerms + ", " +
                              purchaseOrder.Amount + ">");
        }
        else
        {
            Console.Out.WriteLine("Invalid message. Needs to be a Card Payment or Purchase Order.");
        }
    }
}