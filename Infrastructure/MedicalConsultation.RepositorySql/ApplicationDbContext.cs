using MedicalConsultation.RepositorySql.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DbContextOptions;

namespace MedicalConsultation.RepositorySql
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string str = _configuration?.GetSection("ConnectionStrings:ConnectionString")?.Value;
                string str = "Server=localhost\\SQLEXPRESS;Database=TesteUser;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(str);
            }
        }

    }
}
