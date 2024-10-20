using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Validations;

namespace MedicalConsultation.UseCases.Patient
{
    public class IncludePatientUseCase
    {
        private readonly PatientEntity _newEntity;
        private readonly PatientEntity _entityByEmail;

        public IncludePatientUseCase(PatientEntity novoPaciente, PatientEntity pacientePorEmail)
        {
            _newEntity = novoPaciente;
            _entityByEmail = pacientePorEmail;
        }

        public PatientEntity VerificarExistente()
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
