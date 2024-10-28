using MedicalConsultation.Entity;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.UseCases.Patient;

namespace MedicalConsultation.Controller
{
    public class UserController : IUserController
    {
        private readonly IUserGateway _userGateway;

        public UserController(IUserGateway patientGateway)
        {
            _userGateway = patientGateway;
        }

        public UserEntity Alterar(UserEntity entity)
        {
            var registroBase = _userGateway.ObterPorId(entity.Id);
            var registroPorEmail = _userGateway.ObterPorEmail(entity.Email);
            var useCase = new UpdatePatientUseCase(entity, registroBase, registroPorEmail);

            useCase.VerificarExistente();

            registroBase.SetEmail(entity.Email);
            registroBase.SetCpf(entity.CPF);
            registroBase.SetName(entity.Name);

            return _userGateway.Atualizar(registroBase);
        }       

        public IEnumerable<UserEntity> ListarAtivos()
        {
            return _userGateway.ObterAtivos(); 
        }

        public UserEntity ObterUsuarioPorEmail(string email)
        {
            return _userGateway.ObterPorEmail(email);
        }

        public UserEntity ObterUsuarioPorId(int id)
        {
            return _userGateway.ObterPorId(id);
        }

        public UserEntity Incluir(UserEntity entity)
        {
            var registroBase = _userGateway.ObterPorEmail(entity.Email);
            var useCase = new IncludePatientUseCase(entity, registroBase);

            var obj = useCase.VerificarExistente();

            if (obj.Id == 0)
                _userGateway.Incluir(obj);
            else
                _userGateway.Atualizar(obj);//reativação do usuário

            return entity;
        }

        public bool Excluir(int id)
        {
            var patient = _userGateway.ObterPorId(id);
            patient.SetAtivo(false);

            //cancelar consultas

            return _userGateway.Atualizar(patient)!=null;
        }
    }
}
