using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class PatientDaoConverter : IDaoConverter<PatientDao, PatientEntity>
    {
        public PatientEntity Convert(PatientDao dao)
            => new PatientEntity(dao.Id, dao.Name, dao.email, dao.cpf);
    }
}
