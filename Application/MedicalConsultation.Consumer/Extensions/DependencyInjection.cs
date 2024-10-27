using MedicalConsultation.Controller;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Infrastructure;
using MedicalConsultation.Interfaces.Repository;
using MedicalConsultation.Mail;
using MedicalConsultation.Repository;

namespace MedicalConsultation.Consumer.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMailSender, MailSender>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationProcessController, NotificationProcessController>();

            var conexao = configuration["masstransit:azurebus"] ?? string.Empty;
            var filaNotificacao = configuration["masstransit:queuename"] ?? string.Empty;

            services.AddHostedService<ConsumerQueue>();
            return services;
        }
    }
}
