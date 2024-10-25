using MassTransit;
using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Messagins;
using MedicalConsultation.Interfaces.Repository;
using Microsoft.Extensions.Logging;

namespace MedicalConsultation.MassTransit
{
    public class NotificationConsumer : INotificationConsumer
    {
        private readonly INotificationRepository _repository;
        private readonly ILogger<NotificationConsumer> _logger;

        private string htmlTemplate = @"
        <html>
            <body>
                <h1>Olá!</h1>
                <p>Este é um e-mail enviado com <strong>HTML</strong> usando o Azure Communication Services.</p>
                <p>Obrigado!</p>
            </body>
        </html>";
        public NotificationConsumer(INotificationRepository repository, ILogger<NotificationConsumer> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ConsultationNotificationEntity> context)
        {
            var notification = context.Message;

            //enviar email
            //registrar envio no db
            var notificaoes = _repository.ConsultarPorIdConsultaNaData(notification.ConsultaId, DateTime.Now);
            if (notificaoes?.Count() > 0) //já notificado no dia
                return Task.CompletedTask;


            _repository.Incluir(notification);
            //etc

            return Task.CompletedTask;
        }
    }
}
