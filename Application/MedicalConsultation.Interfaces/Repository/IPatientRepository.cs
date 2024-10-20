using MedicalConsultation.Entity.Patient;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface IPatientRepository : IRepository<PatientEntity>
    {
        PatientEntity ConsultarPorEmail(string email);
    }
}
