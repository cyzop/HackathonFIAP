using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.Interfaces.Messagins;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Gateways
{
    public class NotificationGateway : INotificationGateway
    {
        private readonly INotificationProducer _producer;
        private readonly INotificationRepository _repository;

        public NotificationGateway(INotificationProducer producer, INotificationRepository repository)
        {
            _producer = producer;
            _repository = repository;
        }

        public void EnviarNotificacao(ConsultationNotificationEntity notification)
        {
            _producer.SendNotification(notification);
        }

        public IEnumerable<ConsultationNotificationEntity> ObterNotificacoesNaData(DateTime data)
        {
            return _repository.ConsultarPorDataNotificacao(data);
        }

        
    }
}
