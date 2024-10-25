using MedicalConsultation.RepositorySql.Entity;
using MedicalConsultation.RepositorySql.Interface;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.RepositorySql
{
    public class DoctorRepository : UserRepository, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Doctor> GetByCRMAsync(string crm)
        {
            throw new NotImplementedException();


        }
    }
}
