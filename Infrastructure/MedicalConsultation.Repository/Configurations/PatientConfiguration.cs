using MedicalConsultation.Entity.Patient;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.Repository.Configurations
{
    //public class PatientConfiguration : IEntityTypeConfiguration<PatientEntity>
    //{
        //    public void Configure(EntityTypeBuilder<PatientEntity> builder)
        //    {
        //        builder.ToTable("Paciente");
        //        builder.HasKey(p => p.Id);
        //        builder.Property(p => p.Id).HasColumnType("INT");
        //        builder.Property(p => p.Name).HasColumnType("VARCHAR(150)").IsRequired();
        //        builder.Property(p => p.Email).HasColumnType("VARCHAR(150)").IsRequired();
        //        builder.Property(p => p.Cpf).HasColumnType("VARCHAR(14)");
        //        //builder.Property(p => p.Senha).HasColumnType("VARCHAR(100)").IsRequired()
        //        builder.Property(p => p.Ativo).HasColumnType("BIT").IsRequired();
        //    }
    //}
}
