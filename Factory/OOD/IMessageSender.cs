namespace OOD
{
    public interface IMessageSender
    {
        void sendEmail(IPerson person, string message);
    }
}