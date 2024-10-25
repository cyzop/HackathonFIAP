using MedicalConsultation.RepositorySql.Entity;

namespace MedicalConsultation.RepositorySql.Interface
{
    public interface IPatientRepository : IUserRepository
    {
        Task<Patient> GetByCPFAsync(string cpf);
    }
}
