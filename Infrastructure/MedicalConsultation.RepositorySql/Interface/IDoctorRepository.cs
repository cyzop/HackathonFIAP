using MedicalConsultation.RepositorySql.Entity;

namespace MedicalConsultation.RepositorySql.Interface
{
    public interface IDoctorRepository : IUserRepository
    {
        Task<Doctor> GetByCRMAsync(string crm);
    }
}
