namespace EasyNetqMessages;

public class TextMessage
{
    public string Text { get; set; } = default!;
}

public static class Constants
{
    public const string RabbitMqConnectionString = "host=localhost;username=guest;password=guest";
}
