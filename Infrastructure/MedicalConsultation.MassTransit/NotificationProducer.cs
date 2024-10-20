using MassTransit;
using MedicalConsultation.Entity.Notify;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalConsultation.MassTransit
{
    public class NotificationProducer
    {
        private readonly IBus _bus;
        private ILogger<NotificationProducer> _logger;
        private readonly string _queue;
        public NotificationProducer(IBus bus, ILogger<NotificationProducer> logger, IConfiguration config)
        {
            _bus = bus;
            _logger = logger;
            _queue = config.GetSection("masstransit:queuename").ToString() ?? string.Empty;
        }

        public async Task SendNotification(ConsultationNotificationEntity notification)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{_queue}"));
            await endpoint.Send(notification);
        }
    }
}
