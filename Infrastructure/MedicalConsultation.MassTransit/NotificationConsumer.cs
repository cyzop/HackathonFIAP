using MassTransit;
using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Infrastructure;
using MedicalConsultation.Interfaces.Repository;
using Microsoft.Extensions.Logging;

namespace MedicalConsultation.MassTransit
{
    //public class NotificationConsumer : INotificationConsumer
    public class NotificationConsumer : IConsumer<ConsultationNotificationEntity>
    {
        private readonly INotificationRepository _repository;
        private readonly ILogger<NotificationConsumer> _logger;
        private readonly IMailSender mailSender;

        private string htmlTemplate = @"
        <html>
            <body>
                <h1>Olá {0}!</h1>
                <p>Este é um e-mail para informar que sua consulta com o Dr {1} em {2} está {3}.</p>
                <p></p>
                <p>Att, Sistema de Agendamento de Consultas!</p>
            </body>
        </html>";

        public NotificationConsumer(INotificationRepository repository, ILogger<NotificationConsumer> logger, IMailSender mailSender)
        {
            _repository = repository;
            _logger = logger;
            this.mailSender = mailSender;
        }

        public Task Consume(ConsumeContext<ConsultationNotificationEntity> context)
        {
            var notification = context.Message;

            string nomePaciente = notification.Consulta.Paciente.Name;
            string emailPaciente = notification.Consulta.Paciente.Email;
            string nomeMedico = notification.Consulta.Medico.Usuario.Name;
            string dataConsulta = notification.Consulta.Date.ToString("dd/MM/yyyy HH:mm:ss");
            string status = notification.Consulta.Status.ToString();


            //enviar email
            if (!string.IsNullOrEmpty(notification.Message))
            {
                mailSender.SendText(null, emailPaciente, null, notification.Message);
            }
            else
            {
                string body = string.Format(htmlTemplate, nomeMedico, nomeMedico, dataConsulta, status);
                mailSender.SendHtml(null, emailPaciente, null, body);
            }

            
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
