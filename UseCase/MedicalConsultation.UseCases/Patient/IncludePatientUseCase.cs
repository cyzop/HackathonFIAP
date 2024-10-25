using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Validations;

namespace MedicalConsultation.UseCases.Patient
{
    public class IncludePatientUseCase
    {
        private readonly UserEntity _newEntity;
        private readonly UserEntity _entityByEmail;

        public IncludePatientUseCase(UserEntity novoPaciente, UserEntity pacientePorEmail)
        {
            _newEntity = novoPaciente;
            _entityByEmail = pacientePorEmail;
        }

        public UserEntity VerificarExistente()
        {
            if (_entityByEmail!=null && !_entityByEmail.Ativo)
            {
                _entityByEmail.SetAtivo(true);
                return _entityByEmail;
            }
            else
            {
                Assertion.AssertIsNull(_entityByEmail, Messages.UseCaseValidationMessages.PatientValidationMessages.PatientAlreadyExistingWithSameEmail);
                return _newEntity;
            }
        }
    }
}
