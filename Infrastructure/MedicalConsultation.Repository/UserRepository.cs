using MedicalConsultation.Entity;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Repository
{
    public class UserRepository : EFRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UserEntity ConsultarPorEmail(string email)
        {
            return _context.Usuarios
               .Where(p => p.Email.ToLower() == email.ToLower())
               .FirstOrDefault();
        }
    }
}
