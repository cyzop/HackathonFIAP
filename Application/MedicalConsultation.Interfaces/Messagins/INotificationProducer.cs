using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Messagins
{
    public interface INotificationProducer
    {
        Task SendNotification(ConsultationNotificationEntity notification);
    }
}
