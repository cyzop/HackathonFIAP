using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Entity.Schedule;
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

        public DbSet<PatientEntity> Pacientes { get;set; }
        public DbSet<MedicalDoctorEntity> Medicos { get; set; }
        public DbSet<ConsultationEntity> Consultas { get; set; }
        public DbSet<DailySchedulesEntity> HorariosDia { get; set; }
        //public DbSet<MedicalDoctorSchedulesEntity> AgendaMedica { get; set; }
        public DbSet<TimeEntity> Horarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string str = _configuration?.GetSection("ConnectionStrings:ConnectionString")?.Value;
                string str = "Server=localhost\\SQLEXPRESS;Database=HackathonDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(str);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
