using MedicalConsultation.Entity.Consultation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalConsultation.Repository.Configurations
{
    public class ConsultationConfiguration : IEntityTypeConfiguration<ConsultationEntity>
    {
        public void Configure(EntityTypeBuilder<ConsultationEntity> builder)
        {
            builder.ToTable("Consulta");
            builder.HasKey(p=>p.Id);
            builder.Property(p => p.Id).HasColumnType("INT");
            builder.Property(p => p.MedicoId).HasColumnType("INT").IsRequired();
            builder.Property(p => p.PacienteId).HasColumnType("INT").IsRequired();
            builder.Property(p=>p.Date).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Status).HasConversion<string>().IsRequired();
            builder.Property(p=>p.DataStatus).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Ativo).HasColumnType("BIT").IsRequired();
            builder.HasOne(p=>p.Paciente).WithMany().HasPrincipalKey(q=>q.Id);
            builder.HasOne(p=>p.Medico).WithMany().HasPrincipalKey(m=>m.Id);
            //builder.Property(p => p.Senha).HasColumnType("VARCHAR(100)").IsRequired()
        }
    }
}
