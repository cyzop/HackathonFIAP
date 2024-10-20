using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Gateway
{
    public interface INotificationGateway
    {
        void SendNotification(ConsultationNotificationEntity notification);
    }
}
