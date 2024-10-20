using MedicalConsultation.Entity.Consultation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MedicalConsultation.Entity.Schedule;

namespace MedicalConsultation.Repository.Configurations
{
    public class DailyScheduleConfiguration : IEntityTypeConfiguration<DailySchedulesEntity>
    {
        public void Configure(EntityTypeBuilder<DailySchedulesEntity> builder)
        {
            builder.ToTable("HorarioDia");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT");
            builder.Property(p => p.DiaDaSemana).HasConversion<string>().IsRequired();

            builder.HasMany(p => p.Horarios).WithMany().UsingEntity<Dictionary<string, object>>(
                "HorariosDiaSemana",
                j => j.HasOne<TimeEntity>().WithMany().HasForeignKey("HorarioId"),
                j => j.HasOne<DailySchedulesEntity>().WithMany().HasForeignKey("HorarioDiaId")
                );
        }
    }
}
