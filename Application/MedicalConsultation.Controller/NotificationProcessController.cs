using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Infrastructure;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Controller
{
    public class NotificationProcessController : INotificationProcessController
    {
   
        private readonly INotificationRepository _repository;
        private readonly IMailSender mailSender;

        private string htmlTemplate = @"
        <html>
            <body>
                <h1>Olá{0}!</h1>
                <p>Este é um e-mail para informar que sua consulta com o Dr {1} em {2} está {3}.</p>
                <p></p>
                <p>Att, Sistema de Agendamento de Consultas!</p>
            </body>
        </html>";

        public NotificationProcessController(INotificationRepository repository, IMailSender mailSender)
        {
            _repository = repository;
            this.mailSender = mailSender;
        }
        
        public void ProcessMessage(ConsultationNotificationEntity message)
        {
            var notification = message;

            var notificaoes = _repository.ConsultarPorIdConsultaNaData(notification.ConsultaId, DateTime.Today);
            if (notificaoes?.Count() > 0)
            {
                //ja notificado no status a menos de uma hora
                if(notificaoes
                    .Where(n=>n.StatusConsulta == message.Consulta.Status)
                    .FirstOrDefault() != null)
                    return;
            }

            string nomePaciente = notification.Consulta.Paciente.Name;
            string emailPaciente = notification.Consulta.Paciente.Email;
            string nomeMedico = notification.Consulta.Medico.Usuario.Name;
            string dataConsulta = notification.Consulta.Date.ToString("dd/MM/yyyy HH:mm:ss");
            string status = notification.Consulta.Status.ToString();

            //gerar mensagem
            string body = string.Empty;
            if (string.IsNullOrEmpty(notification.Message))
                body = string.Format(htmlTemplate, nomeMedico, nomeMedico, dataConsulta, status);
            else
                body = notification.Message;

            //Enviar email
            mailSender.SendHtml(null, emailPaciente, null, body);

            //Limpar antes de persistir
            notification.Message = $"Medico:{nomeMedico}, Paciente:{nomePaciente} - {emailPaciente}, DataConsulta: {dataConsulta} ";
            notification.StatusConsulta = notification.Consulta.Status;
            notification.Consulta = null;
            
            //Registrar envio
            _repository.Incluir(notification);
        }
    }
}
