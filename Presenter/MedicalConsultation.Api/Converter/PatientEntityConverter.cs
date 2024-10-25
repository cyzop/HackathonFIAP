using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class PatientEntityConverter : IEntityConverter<UserEntity, PatientDao>
    {
        public PatientDao Convert(UserEntity entity)
        {
            return entity!=null ? new PatientDao()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                cpf = entity.CPF,
                Ativo = entity.Ativo
            } : null;
        }
    }
}
