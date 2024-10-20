using MedicalConsultation.Entity.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalConsultation.Repository.Configurations
{
    public class TimeConfiguration : IEntityTypeConfiguration<TimeEntity>
    {
        public void Configure(EntityTypeBuilder<TimeEntity> builder)
        {
            builder.ToTable("Horario");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT");
            builder.Property(p => p.Hora).HasColumnType("TIME").IsRequired();
        }
    }
}
