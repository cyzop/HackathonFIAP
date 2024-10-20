using MedicalConsultation.Api.Converter;
using MedicalConsultation.Controller;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Gateways;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.Interfaces.Repository;
using MedicalConsultation.Repository;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConverters();
            services.AddRepositories();
            services.AddGateways();
            services.AddDomainController();

            return services;
        }
        public static IServiceCollection AddConverters(this IServiceCollection services)
        {
            services.AddScoped<IDaoConverter<PatientDao, PatientEntity>, PatientDaoConverter>();
            services.AddScoped<IDaoConverter<MedicalDoctorDao, MedicalDoctorEntity>, MedicalDoctorDaoConverter>();
            services.AddScoped<IDaoConverter<ConsultationDao, ConsultationEntity>, ConsultationDaoConverter>();

            services.AddScoped<IEntityConverter<ConsultationEntity, ConsultationDao>, ConsultationEntityConverter>();
            return services;
        }
        public static IServiceCollection AddDomainController(this IServiceCollection services)
        {
            services.AddScoped<IPatientController, PatientController>();
            services.AddScoped<IMedicalDoctorController, MedicalDoctorController>();
            services.AddScoped<IConsultationController, ConsultationController>();

            return services;
        }

        public static IServiceCollection AddGateways(this IServiceCollection services)
        {
            services.AddScoped<IPatientGateway, PatientGateway>();
            services.AddScoped<IMedicalDoctorGateway, MedicalDoctorGateway>();
            services.AddScoped<IConsultationGateway, ConsultationGateway>();
            services.AddScoped<INotificationGateway, NotificationGateway>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IMedicalDoctorRepository, MedicalDoctorRepository>();
            services.AddScoped<IConsultationRepository, ConsultationRepository>();
            return services;
        }

    }
}
