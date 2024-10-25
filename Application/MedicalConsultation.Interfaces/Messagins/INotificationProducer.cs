using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Messagins
{
    public interface INotificationProducer
    {
        void SendNotification(ConsultationNotificationEntity notification);
    }
}
