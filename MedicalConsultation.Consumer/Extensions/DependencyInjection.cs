using MassTransit;
using MedicalConsultation.Interfaces.Infrastructure;
using MedicalConsultation.Interfaces.Messagins;
using MedicalConsultation.Mail;

namespace MedicalConsultation.Consumer.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMailSender, MailSender>();

            var conexao = configuration["postechcadpac:masstransit:azurebus"] ?? string.Empty;
            var filaNotificacao = configuration.GetSection("MedicalHistoryAzureBus")["QueueName"] ?? string.Empty;

            services.AddMassTransit(x =>
            {
                x.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host(conexao);

                    cfg.ReceiveEndpoint(filaNotificacao, e =>
                    {
                        e.ConfigureConsumer<INotificationConsumer>(context);
                    });
                });

                x.AddConsumer<INotificationConsumer> ();
            });

            return services;
        }
    }
}
