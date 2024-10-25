using MedicalConsultation.Entity;

namespace MedicalConsultation.Interfaces.Controller
{
    public interface IUserController
    {
        UserEntity Incluir(UserEntity entity);
        UserEntity Alterar(UserEntity entity);
        bool Excluir(int id);
        UserEntity ObterUsuarioPorEmail(string email);
        UserEntity ObterUsuarioPorId(int id);

        IEnumerable<UserEntity> ListarAtivos();
    }
}
