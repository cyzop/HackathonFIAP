using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalConsultation.MassTransit.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceBuz(this IServiceCollection services, IConfiguration config)
        {
            var conexao = config.GetSection("masstransit:azurebus").ToString() ?? string.Empty;
            var queue = config.GetSection("masstransit:queuename").ToString() ?? string.Empty;

            services.AddMassTransit(m =>
            {
                m.UsingAzureServiceBus((context, conf) =>
                {
                    conf.Host(conexao);
                    conf.ReceiveEndpoint(queue, e =>
                    {
                        e.ConfigureConsumer<NotificationConsumer>(context);
                    });
                });
                m.AddConsumer<NotificationConsumer>();
            });

            return services;
        }
    }
}
