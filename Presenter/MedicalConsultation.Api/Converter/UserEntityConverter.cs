using MedicalConsultation.Entity;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class UserEntityConverter : IEntityConverter<UserEntity, UserDao>
    {
        public UserDao Convert(UserEntity entity)
        {
            return entity != null ? new UserDao()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                cpf = entity.CPF,
                Ativo = entity.Ativo
            } : null;
        }
    }
}
