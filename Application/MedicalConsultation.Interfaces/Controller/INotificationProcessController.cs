using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Controller
{
    public interface INotificationProcessController
    {
        void ProcessMessage(ConsultationNotificationEntity message);
    }
}
