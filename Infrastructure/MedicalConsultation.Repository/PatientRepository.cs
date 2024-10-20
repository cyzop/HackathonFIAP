using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Repository
{
    public class PatientRepository : EFRepository<PatientEntity>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public PatientEntity ConsultarPorEmail(string email)
        {
            return _context.Pacientes
                .Where(p=>p.Email.ToLower() == email.ToLower())
                .FirstOrDefault();
        }
    }
}
