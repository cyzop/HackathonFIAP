using MedicalConsultation.RepositorySql.Entity;
using MedicalConsultation.RepositorySql.Interface;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.RepositorySql
{
    public class PatientRepository : UserRepository, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Patient> GetByCPFAsync(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
