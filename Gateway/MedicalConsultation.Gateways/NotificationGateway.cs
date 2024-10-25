using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.Interfaces.Messagins;

namespace MedicalConsultation.Gateways
{
    public class NotificationGateway : INotificationGateway
    {
        private readonly INotificationProducer _producer;

        public NotificationGateway(INotificationProducer producer)
        {
            _producer = producer;
        }

        public void SendNotification(ConsultationNotificationEntity notification)
        {
            throw new NotImplementedException();
        }
    }
}
