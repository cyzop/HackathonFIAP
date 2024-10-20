using MedicalConsultation.Entity.MedicalDoctor;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface IMedicalDoctorRepository : IRepository<MedicalDoctorEntity>
    {
        MedicalDoctorEntity ConsultarPorEmail(string email);
    }
}
