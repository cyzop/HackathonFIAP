using MedicalConsultation.RepositorySql.Entity;

namespace MedicalConsultation.RepositorySql.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
