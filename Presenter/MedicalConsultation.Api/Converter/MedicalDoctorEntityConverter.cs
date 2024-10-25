using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class MedicalDoctorEntityConverter : IEntityConverter<MedicalDoctorEntity, MedicalDoctorDao>
    {
        public MedicalDoctorDao Convert(MedicalDoctorEntity entity)
        {
            return entity!=null ?
                new MedicalDoctorDao()
                {
                    Id = entity.Id,
                    Crm = entity.CRM,
                    Especialidade = entity.Especialidade,
                    Name = entity.Usuario?.Name,
                    email = entity.Usuario?.Email,
                    CPF = entity.Usuario?.CPF
                } : null;
        }
    }
}
