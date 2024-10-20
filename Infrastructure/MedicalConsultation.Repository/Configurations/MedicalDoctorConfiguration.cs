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
            builder.Property(p => p.Name).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(p => p.Especialidade).HasColumnType("VARCHAR(150)");
            builder.Property(p => p.CRM).HasColumnType("VARCHAR(20)");
            builder.Property(p => p.Ativo).HasColumnType("BIT").IsRequired();
            //builder.Property(p => p.Senha).HasColumnType("VARCHAR(100)").IsRequired()
        }
    }
}
