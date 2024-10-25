using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalConsultation.RepositorySql.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TesteUser;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"));
            return services;
        }
    }
}
