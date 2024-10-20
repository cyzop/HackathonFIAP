using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Validations;

namespace MedicalConsultation.UseCases.MedicalDoctor
{
    public class UpdateMedicalDoctorUseCase
    {
        private readonly MedicalDoctorEntity _novoMedico;
        private readonly MedicalDoctorEntity _medicoById;
        private readonly MedicalDoctorEntity _medicoByEmail;

        public UpdateMedicalDoctorUseCase(MedicalDoctorEntity novoMedico, MedicalDoctorEntity medicoById, MedicalDoctorEntity medicoByEmail)
        {
            _novoMedico = novoMedico;
            _medicoById = medicoById;
            _medicoByEmail = medicoByEmail;
        }

        public MedicalDoctorEntity VerificarExistente()
        {
            Assertion.AssertIsNotNull(_medicoById, Messages.UseCaseValidationMessages.MedicalDoctorValidationMessages.MedicalDoctorNotFound);

            Assertion.AssertIfEquals(_medicoById.Id, _medicoByEmail.Id, Messages.UseCaseValidationMessages.MedicalDoctorValidationMessages.MedicalDoctorAlreadyExistingWithSameEmail);

            return _novoMedico; 
        }
    }
}
