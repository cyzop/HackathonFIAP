using MedicalConsultation.Entity;

namespace MedicalConsultation.Interfaces.Gateway
{
    public interface IUserGateway
    {
        UserEntity ObterPorId(int id);
        UserEntity ObterPorEmail(string email);
        List<UserEntity> ObterAtivos();

        void Incluir(UserEntity patient);
        UserEntity Atualizar(UserEntity patient);
    }
}
