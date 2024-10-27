using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Gateway;

namespace MedicalConsultation.Controller
{
    public class ConsultationNotificationController : INotificationController
    {
        private readonly INotificationGateway _notificationGateway;
        private readonly IConsultationGateway _consultationGateway;

        const string htmlTemplate = @"
        <html>
            <body>
                <h1>Olá {0}!</h1>
                <p>{1}</p>
                <p></p>
                <p>Att, Sistema de Agendamento de Consultas!</p>
            </body>
        </html>";


        public ConsultationNotificationController(INotificationGateway notificationGateway, IConsultationGateway consultationGateway)
        {
            _notificationGateway = notificationGateway;
            _consultationGateway = consultationGateway;
        }

        public IEnumerable<ConsultationNotificationEntity> GerarNotificacoesConsulta()
        {
            DateTime dataVerificacaoConsulta = DateTime.Today.AddDays(1);//amanhã

            //verificar consultas para diaseguinte
            List<ConsultationNotificationEntity> notificacoes = new List<ConsultationNotificationEntity>();
            var consultasProximas = _consultationGateway.ObterConsultasPorData(dataVerificacaoConsulta);
            if (consultasProximas?.Count() > 0)
            {
                var notificacoesdiacorrente = _notificationGateway.ObterNotificacoesNaData(dataVerificacaoConsulta);
                consultasProximas.ToList().ForEach(c =>
                {
                    if (notificacoesdiacorrente.Where(n => n.ConsultaId == c.Id && n.Consulta.Status == c.Status).FirstOrDefault() == null)
                    {
                        //se consulta não foi notificar na data corrente1
                        var notification = new ConsultationNotificationEntity(c, DateTime.Now);
                        string strInformation = GetNotificationMessage(c);
                        string body = string.Format(htmlTemplate, c.Paciente.Name, strInformation);
                        
                        notification.SetMessage(body);

                        _notificationGateway.EnviarNotificacao(notification);
                        notificacoes.Add(notification);
                    }
                });
                if (notificacoes?.Count() > 0)
                    return notificacoes;
            }
            return null;
        }

        private string GetNotificationMessage(ConsultationEntity c)
        {
            string text = "Notificação de Consulta";
            switch (c.Status)
            {
                case Entity.ConsultationStatus.Agendada:
                    text = $"Este é um e-mail para lembrar de sua consulta com o Dr {c.Medico.Usuario.Name} em {c.Date.ToString("dd/MM/yyyy HH:mm:ss")}";
                    break;
                case Entity.ConsultationStatus.Reagendada:
                    text = $"Este é um e-mail para lembrar de sua consulta com o Dr {c.Medico.Usuario.Name} foi reagendada para {c.Date.ToString("dd/MM/yyyy HH:mm:ss")}";
                    break;
                case Entity.ConsultationStatus.Cancelada:
                    text = $"Este é um e-mail para informar o CANCELAMENTO de sua consulta que estava marcada para {c.Date.ToString("dd/MM/yyyy HH:mm:ss")} com o Dr {c.Medico.Usuario.Name}";
                    break;
            }
            return text;
        }

    }

}
