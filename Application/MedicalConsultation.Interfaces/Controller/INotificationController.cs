using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Controller
{
    public interface INotificationController
    {
        IEnumerable<ConsultationNotificationEntity> GerarNotificacoesConsulta();
    }
}
