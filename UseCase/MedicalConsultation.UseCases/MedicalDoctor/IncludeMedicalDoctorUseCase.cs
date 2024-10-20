using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Validations;

namespace MedicalConsultation.UseCases.MedicalDoctor
{
    public class IncludeMedicalDoctorUseCase
    {
        private readonly MedicalDoctorEntity _novoMedico;
        private readonly MedicalDoctorEntity _medicoByEmail;

        public IncludeMedicalDoctorUseCase(MedicalDoctorEntity novoMedico, MedicalDoctorEntity medicoByEmail)
        {
            _novoMedico = novoMedico;
            _medicoByEmail = medicoByEmail;
        }

        public MedicalDoctorEntity VerificarExistente()
        {
            if (_medicoByEmail!=null && !_medicoByEmail.Ativo)
            {
                _medicoByEmail.SetAtivo(true);
                return _medicoByEmail;
            }
            else
            {
                Assertion.AssertIsNull(_medicoByEmail, Messages.UseCaseValidationMessages.MedicalDoctorValidationMessages.MedicalDoctorAlreadyExistingWithSameEmail);
                return _novoMedico;
            }
        }
    }
}
