using MedicalConsultation.Entity.Notify;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalConsultation.Repository.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<ConsultationNotificationEntity>
    {
        public void Configure(EntityTypeBuilder<ConsultationNotificationEntity> builder)
        {
            builder.ToTable("Notificacao");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT");
            builder.Property(p => p.Data).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Message).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(p=> p.StatusConsulta).HasConversion<string>().IsRequired();
            builder.Property(p => p.ConsultaId).HasColumnType("INT");
            builder.HasOne(p => p.Consulta).WithMany().HasPrincipalKey(q => q.Id);
        }
    }
}
