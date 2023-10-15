using EasyNetQ;
using EasyNetqMessages;
using static EasyNetqMessages.Constants;

for (int i = 0; i < 10; i++)
{
    using var bus = RabbitHutch.CreateBus(RabbitMqConnectionString);

    await bus.PubSub.PublishAsync(new TextMessage
    {
        Text = i + ": Hello World from EasyNetQ"
    });
}
