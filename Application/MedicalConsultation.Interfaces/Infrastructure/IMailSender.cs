namespace MedicalConsultation.Interfaces.Infrastructure
{
    public interface IMailSender
    {
        void SendHtml(string senderAddress, string recipientAddress, string subject, string html);
        void SendText(string senderAddress, string recipientAddress, string subject, string text);
    }
}
