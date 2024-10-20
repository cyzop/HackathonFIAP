using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Validations;

namespace MedicalConsultation.UseCases.Consultation
{
    public class IncludeConsultationUseCase
    {
        private readonly MedicalDoctorEntity _medico;
        private readonly PatientEntity _paciente;
        private readonly ConsultationEntity _consultaMesmoHorarioMedico;
        private readonly ConsultationEntity _consultaMesmoHorarioPaciente;
        private readonly ConsultationEntity _novaConsulta;

        public IncludeConsultationUseCase(
            MedicalDoctorEntity medico, 
            PatientEntity paciente, 
            ConsultationEntity consultaMesmoHorarioMedico,
            ConsultationEntity consultaMesmoHorarioPaciente,
            ConsultationEntity novaConsulta)
        {
            _consultaMesmoHorarioMedico = consultaMesmoHorarioMedico;
            _consultaMesmoHorarioPaciente = consultaMesmoHorarioPaciente;
            _medico = medico;
            _paciente = paciente;       
            _novaConsulta = novaConsulta;
        }

        public ConsultationEntity VerificarExistente()
        {
            Assertion.AssertIsNotNull(_medico, Messages.UseCaseValidationMessages.MedicalDoctorValidationMessages.MedicalDoctorNotFound);
            Assertion.AssertIsNotNull(_paciente, Messages.UseCaseValidationMessages.PatientValidationMessages.PatientNotFound);

            Assertion.AssertIsNull(_consultaMesmoHorarioPaciente, Messages.UseCaseValidationMessages.ConsultationValidationMessages.PatientWithConsultationAtTheSameTime);
            Assertion.AssertIsNull(_consultaMesmoHorarioMedico, Messages.UseCaseValidationMessages.ConsultationValidationMessages.MedicalDoctorWithConsultationAtTheSameTime);

            return new ConsultationEntity(_paciente, 
                _medico, 
                _novaConsulta.Date, 
                ConsultationStatus.Agendada, 
                DateTime.Now);
        }
    }
}
