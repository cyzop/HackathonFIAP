using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.UseCases.MedicalDoctor;
using MedicalConsultation.UseCases.Patient;

namespace MedicalConsultation.Controller
{
    public class PatientController : IPatientController
    {
        private readonly IPatientGateway _patientGateway;

        public PatientController(IPatientGateway patientGateway)
        {
            _patientGateway = patientGateway;
        }

        public PatientEntity Alterar(PatientEntity entity)
        {
            var registroBase = _patientGateway.ObterPorId(entity.Id);
            var registroPorEmail = _patientGateway.ObterPorEmail(entity.Email);
            var useCase = new UpdatePatientUseCase(entity, registroBase, registroPorEmail);

            useCase.VerificarExistente();

            registroBase.SetEmail(entity.Email);
            registroBase.SetCpf(entity.Cpf);
            registroBase.SetName(entity.Name);

            return _patientGateway.Atualizar(entity);
        }       

        public IEnumerable<PatientEntity> ListarAtivos()
        {
            return _patientGateway.ObterAtivos(); 
        }

        public PatientEntity ObterUsuarioPorEmail(string email)
        {
            return _patientGateway.ObterPorEmail(email);
        }

        public PatientEntity ObterUsuarioPorId(int id)
        {
            return _patientGateway.ObterPorId(id);
        }

        public PatientEntity Incluir(PatientEntity entity)
        {
            var registroBase = _patientGateway.ObterPorEmail(entity.Email);
            var useCase = new IncludePatientUseCase(entity, registroBase);

            var obj = useCase.VerificarExistente();

            if (obj.Id == 0)
                _patientGateway.Incluir(obj);
            else
                _patientGateway.Atualizar(obj);//reativação do usuário

            return entity;
        }

        public bool Excluir(int id)
        {
            var patient = _patientGateway.ObterPorId(id);
            patient.SetAtivo(false);

            //cancelar consultas

            return _patientGateway.Atualizar(patient)!=null;
        }
    }
}
