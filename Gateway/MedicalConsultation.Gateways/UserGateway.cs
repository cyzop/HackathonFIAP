using MedicalConsultation.Entity;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Gateways
{
    public class UserGateway : IUserGateway
    {
        private readonly IUserRepository _userRepository;

        public UserGateway(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserEntity Atualizar(UserEntity entity)
        {
            _userRepository.Alterar(entity);
            return entity;
        }

        public void Incluir(UserEntity entity)
        {
            _userRepository.Incluir(entity);
        }

        public List<UserEntity> ObterAtivos()
        {
            return _userRepository.ConsultarAtivos().ToList();
        }

        public UserEntity ObterPorEmail(string email)
        {
            return _userRepository.ConsultarPorEmail(email);
        }

        public UserEntity ObterPorId(int id)
        {
            return _userRepository.ConsultarPorId(id);
        }
    }
}
