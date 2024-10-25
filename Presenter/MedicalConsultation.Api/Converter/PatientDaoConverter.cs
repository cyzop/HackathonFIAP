using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class PatientDaoConverter : IDaoConverter<PatientDao, UserEntity>
    {
        public UserEntity Convert(PatientDao dao)
            => new UserEntity(dao.Id, dao.Name, dao.cpf, dao.Email);
    }
}
