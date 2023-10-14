using EasyNetQ;
using EasyNetqMessages;

for (int i = 0; i < 10; i++)
{
    using var bus = RabbitHutch.CreateBus("host=localhost");

    bus.PubSub.Publish(new TextMessage
    {
        Text = i + ": Hello World from EasyNetQ"
    });
}
