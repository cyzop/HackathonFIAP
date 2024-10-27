using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Gateway
{
    public interface INotificationGateway
    {
        void EnviarNotificacao(ConsultationNotificationEntity notification);
        IEnumerable<ConsultationNotificationEntity> ObterNotificacoesNaData(DateTime data);
    }
}
