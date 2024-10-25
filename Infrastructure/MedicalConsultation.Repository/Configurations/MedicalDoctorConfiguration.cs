using MedicalConsultation.Entity.MedicalDoctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalConsultation.Repository.Configurations
{
    public class MedicalDoctorConfiguration : IEntityTypeConfiguration<MedicalDoctorEntity>
    {
        public void Configure(EntityTypeBuilder<MedicalDoctorEntity> builder)
        {
            builder.ToTable("Medico");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT");
            builder.Property(p => p.Especialidade).HasColumnType("VARCHAR(150)");
            builder.Property(p => p.CRM).HasColumnType("VARCHAR(20)");
            builder.HasOne(p => p.Usuario).WithMany().HasPrincipalKey(q => q.Id);
        }
    }
}
