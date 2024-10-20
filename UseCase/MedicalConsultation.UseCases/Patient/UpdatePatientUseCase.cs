using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Validations;

namespace MedicalConsultation.UseCases.Patient
{
    public class UpdatePatientUseCase
    {
        private readonly PatientEntity _novo;
        private readonly PatientEntity _byId;
        private readonly PatientEntity _byEmail;

        public UpdatePatientUseCase(PatientEntity novo, PatientEntity byId, PatientEntity byEmail)
        {
            _novo = novo;
            _byId = byId;
            _byEmail = byEmail;
        }

        public PatientEntity VerificarExistente()
        {
            Assertion.AssertIsNotNull(_byId, Messages.UseCaseValidationMessages.PatientValidationMessages.PatientNotFound);

            Assertion.AssertIfEquals(_byId.Id, _byEmail.Id, Messages.UseCaseValidationMessages.PatientValidationMessages.PatientAlreadyExistingWithSameEmail);

            return _novo;
        }
    }
}
