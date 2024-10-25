using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class MedicalDoctorDaoConverter : IDaoConverter<MedicalDoctorDao, MedicalDoctorEntity>
    {
        public MedicalDoctorEntity Convert(MedicalDoctorDao dao)
            => new MedicalDoctorEntity(dao.Id, dao.Name, dao.CPF, dao.email, dao.Crm, dao.Especialidade);
    }
}
