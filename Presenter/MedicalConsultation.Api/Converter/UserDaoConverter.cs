using MedicalConsultation.Entity;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class UserDaoConverter : IDaoConverter<UserDao, UserEntity>
    {
        public UserEntity Convert(UserDao dao)
        {
            return new UserEntity(dao.Id, dao.Name, dao.cpf, dao.Email);
        }
    }
}
