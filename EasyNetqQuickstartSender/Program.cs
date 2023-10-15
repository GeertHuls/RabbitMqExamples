using EasyNetQ;
using EasyNetqMessages;

for (int i = 0; i < 10; i++)
{
    using var bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");

    await bus.PubSub.PublishAsync(new TextMessage
    {
        Text = i + ": Hello World from EasyNetQ"
    });
}
