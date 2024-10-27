using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Validations;

namespace MedicalConsultation.UseCases.Patient
{
    public class UpdatePatientUseCase
    {
        private readonly UserEntity _novo;
        private readonly UserEntity _byId;
        private readonly UserEntity _byEmail;

        public UpdatePatientUseCase(UserEntity novo, UserEntity byId, UserEntity byEmail)
        {
            _novo = novo;
            _byId = byId;
            _byEmail = byEmail;
        }

        public UserEntity VerificarExistente()
        {
            Assertion.AssertIsNotNull(_byId, Messages.UseCaseValidationMessages.PatientValidationMessages.PatientNotFound);

            Assertion.AssertIfEquals(_byId.Id, _byEmail.Id, Messages.UseCaseValidationMessages.PatientValidationMessages.PatientAlreadyExistingWithSameEmail);

            return _novo;
        }
    }
}
