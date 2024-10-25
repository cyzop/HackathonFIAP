using MedicalConsultation.WebApp.Services;

namespace MedicalConsultation.WebApp.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            //services.AddBlazoredLocalStorage();

            services.AddSingleton<UsuarioService>();

            services.AddTransient<MedicalDoctorApi>();
            services.AddTransient<PatientApi>();
            services.AddTransient<ConsultationApi>();
            services.AddTransient<UserApi>();

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

            services.AddHttpClient("ConsultationApi", client =>
            {
                client.BaseAddress = new Uri(config["ConsultationApi:url"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient("UserApi", client =>
            {
                client.BaseAddress = new Uri(config["UserApi:url"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
