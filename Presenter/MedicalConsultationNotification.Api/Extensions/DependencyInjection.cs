using MassTransit;
using MedicalConsultation.Controller;
using MedicalConsultation.Gateways;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.Interfaces.Messagins;
using MedicalConsultation.Interfaces.Repository;
using MedicalConsultation.MassTransit;
using MedicalConsultation.Repository;


namespace MedicalConsultationNotification.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessaging(configuration);
            services.AddRepositories();
            services.AddGateways();
            services.AddDomainController();

            return services;
        }

        public static IServiceCollection AddDomainController(this IServiceCollection services)
        {
            services.AddScoped<INotificationController, ConsultationNotificationController>();
            services.AddScoped<INotificationProducer, NotificationProducer>();
            return services;
        }

        public static IServiceCollection AddGateways(this IServiceCollection services)
        {
            services.AddScoped<INotificationGateway, NotificationGateway>();
            services.AddScoped<IConsultationGateway, ConsultationGateway>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IConsultationRepository, ConsultationRepository>();
            
            return services;
        }

        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            var conexao = configuration["masstransit:azurebus"] ?? string.Empty;
          
            services.AddMassTransit((x => {
                x.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host(conexao);
                });
            }));

            return services;
        }

    }
}
