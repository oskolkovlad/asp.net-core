namespace Services_DI.Services
{
    public class SmsMessageSender : IMessageSender
    {
        public string Send() => "Sent by SMS...";
    }
}
