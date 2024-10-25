using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Patient;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface IPatientRepository : IRepository<PatientEntity>
    //public interface IPatientRepository : IPersonRepository<UserEntity>
    {
        PatientEntity ConsultarPorEmail(string email);
    }
}
