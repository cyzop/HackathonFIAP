using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.Notify;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalConsultation.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<UserEntity> Usuarios { get; set; }
        public DbSet<ConsultationEntity> Consultas { get; set; }
        public DbSet<ConsultationNotificationEntity> Notificacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string str = _configuration["ConnectionStrings:ConnectionString"]??
                            "Server=localhost\\SQLEXPRESS;Database=HackathonDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(str);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
