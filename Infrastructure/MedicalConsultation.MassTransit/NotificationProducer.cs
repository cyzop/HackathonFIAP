using MassTransit;
using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Messagins;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalConsultation.MassTransit
{
    public class NotificationProducer : INotificationProducer
    {
        private readonly IBus _bus;
        private ILogger<NotificationProducer> _logger;
        private readonly string _queue;
        public NotificationProducer(IBus bus, ILogger<NotificationProducer> logger, IConfiguration config)
        {
            _bus = bus;
            _logger = logger;
            _queue = config["masstransit:queuename"] ?? string.Empty;
        }

        public async Task SendNotification(ConsultationNotificationEntity notification)
        {
            try
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{_queue}"));
                await endpoint.Send(notification);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
