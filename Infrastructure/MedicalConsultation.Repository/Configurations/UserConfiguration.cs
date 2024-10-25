using MedicalConsultation.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalConsultation.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT");
            builder.Property(p => p.Name).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnType("BIT").IsRequired();
            builder.Property(p => p.CPF).HasColumnType("VARCHAR(14)");
        }
    }
}

