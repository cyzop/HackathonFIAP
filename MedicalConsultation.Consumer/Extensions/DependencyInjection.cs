using MassTransit;
using MedicalConsultation.Controller;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Infrastructure;
using MedicalConsultation.Interfaces.Messagins;
using MedicalConsultation.Interfaces.Repository;
using MedicalConsultation.Mail;
using MedicalConsultation.MassTransit;
using MedicalConsultation.Repository;

namespace MedicalConsultation.Consumer.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMailSender, MailSender>();
            //services.AddScoped<INotificationConsumer, NotificationConsumer>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationProcessController, NotificationProcessController>();
            //services.AddSingleton<INotificationProcessControllerFactory, NotificationProcessControllerFactory>();

            var conexao = configuration["masstransit:azurebus"] ?? string.Empty;
            var filaNotificacao = configuration["masstransit:queuename"] ?? string.Empty;

            services.AddHostedService<ConsumerQueue>();

            //services.AddMassTransit(x =>
            //{
            //    x.AddConsumer<NotificationConsumer>();

            //    x.UsingAzureServiceBus((context, cfg) =>
            //    {
            //        cfg.Host(conexao);

            //        cfg.ReceiveEndpoint(filaNotificacao, e =>
            //        {
            //            e.ConfigureConsumer<NotificationConsumer>(context);
            //        });
            //    });
            //});

            return services;
        }
    }
}
