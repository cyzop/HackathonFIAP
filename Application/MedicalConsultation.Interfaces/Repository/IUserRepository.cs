using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Patient;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity ConsultarPorEmail(string email);
    }
}
