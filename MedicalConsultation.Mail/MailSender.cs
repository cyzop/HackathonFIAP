using Azure.Communication.Email;
using MedicalConsultation.Interfaces.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalConsultation.Mail
{
    public class MailSender : IMailSender
    {
        private readonly ILogger<MailSender> _logger;
        private readonly string connectionString;
        private readonly string defaultSenderAddress;
        private readonly string defaultsubject;

        public MailSender(ILogger<MailSender> logger, IConfiguration config)
        {
            _logger = logger;
            connectionString = config["mail:azurecs"]?? string.Empty;
            defaultSenderAddress = config["mail:senderAddress"] ?? string.Empty;
            defaultsubject = config["mail:subject"] ?? string.Empty;
        }

        public void SendHtml(string senderAddress, string recipientAddress, string subject, string html)
        {
            Send(senderAddress?? defaultSenderAddress, 
                recipientAddress, 
                subject?? defaultsubject, 
                html, 
                null);
        }
        public void SendText(string senderAddress, string recipientAddress, string subject, string text)
        {
            Send(senderAddress ?? defaultSenderAddress,
               recipientAddress,
               subject ?? defaultsubject,
               null,
               text);
        }
        private void Send(string senderAddress, string recipientAddress, string subject, string hmlContent = null, string plainText = null)
        {
            try
            {
                EmailClient emailClient = new EmailClient(connectionString);
                EmailMessage emailMessage = new EmailMessage(
                    senderAddress,
                    recipientAddress,
                    new EmailContent(subject)
                    {
                        Html = hmlContent,
                        PlainText = plainText
                    });

                var cancellationToken = new CancellationToken();

                var result = emailClient.Send(Azure.WaitUntil.Completed, emailMessage, cancellationToken);

                _logger.LogInformation($"MainSender.SendHtml id:{result.Id} recipient:{recipientAddress}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"MainSender.SendHtml Error:{ex.Message}");
            }
        }
    }
}
