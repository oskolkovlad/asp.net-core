using Services_DI.Services;

namespace Services_DI.DependencesTransfer
{
    public class MessageService
    {
        IMessageSender _messageSender;
        public MessageService(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public string Send() => _messageSender.Send();
    }
}
