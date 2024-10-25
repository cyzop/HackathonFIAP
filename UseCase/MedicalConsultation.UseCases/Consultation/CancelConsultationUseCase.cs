using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Messages.UseCaseValidationMessages;
using MedicalConsultation.Validations;

namespace MedicalConsultation.UseCases.Consultation
{
    public class CancelConsultationUseCase
    {
        private readonly ConsultationEntity _consultaMarcada;

        public CancelConsultationUseCase(ConsultationEntity consultaMarcada)
        {
            _consultaMarcada = consultaMarcada;
        }

        public ConsultationEntity VerificarCancelamento()
        {
            Assertion.AssertIsNotNull(_consultaMarcada, ConsultationValidationMessages.ConsultationNotFound);
            Assertion.AssertIfDataIsGreaterThanOrEquals(_consultaMarcada.Date, DateTime.Now, ConsultationValidationMessages.ConsultationDateHasPasses);

            return new ConsultationEntity(_consultaMarcada.Id, 
                _consultaMarcada.Paciente, 
                _consultaMarcada.Medico, 
                _consultaMarcada.Date, 
                ConsultationStatus.Cancelada, 
                DateTime.Now);
        }
    }
}
