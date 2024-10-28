using MedicalConsultation.WebApp.Services;

namespace MedicalConsultation.WebApp.Client.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<UsuarioService>();
            services.AddTransient<ConsultationApi>();

            services.AddHttpClient("ConsultationApi", client =>
            {
                client.BaseAddress = new Uri(config["ConsultationApi:url"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient("MedicalDoctorApi", client =>
            {
                client.BaseAddress = new Uri(config["MedicalDoctorApi:url"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient("PatientApi", client =>
            {
                client.BaseAddress = new Uri(config["PatientApi:url"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
