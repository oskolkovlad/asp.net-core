namespace Services_DI.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send() => "Sent by E-Mail...";
    }
}
