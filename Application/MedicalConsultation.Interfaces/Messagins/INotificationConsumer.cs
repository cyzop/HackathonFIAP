using MassTransit;
using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Messagins
{
    public interface INotificationConsumer : IConsumer<ConsultationNotificationEntity>
    {
    }
}
