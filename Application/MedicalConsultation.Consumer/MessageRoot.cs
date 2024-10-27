using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Consumer
{
    public class MessageRoot
    {
        public string MessageId { get; set; }
        public ConsultationNotificationEntity Message { get; set; }

        public MessageRoot()
        {
        }
    }
}
