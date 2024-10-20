using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Repository
{
    public class MedicalDoctorRepository : EFRepository<MedicalDoctorEntity>, IMedicalDoctorRepository
    {
        public MedicalDoctorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MedicalDoctorEntity ConsultarPorEmail(string email)
        {
            return _context.Medicos
                .Where(p => p.Email.ToLower() == email.ToLower())
                .FirstOrDefault();
        }
    }
}
