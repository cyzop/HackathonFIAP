using MassTransit;
using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.MassTransit
{
    public class NotificationConsumer : IConsumer<ConsultationNotificationEntity>
    {
        public NotificationConsumer()
        {
        }

        public Task Consume(ConsumeContext<ConsultationNotificationEntity> context)
        {
            var notification = context.Message;

            return Task.CompletedTask;
        }
    }
}
