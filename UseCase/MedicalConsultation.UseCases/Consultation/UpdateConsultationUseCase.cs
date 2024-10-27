using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity;
using MedicalConsultation.Validations;
using MedicalConsultation.Messages.UseCaseValidationMessages;

namespace MedicalConsultation.UseCases.Consultation
{
    public class UpdateConsultationUseCase
    {
        private readonly ConsultationEntity _consultaMarcada;
        private readonly ConsultationEntity _consultaAlterar;

        public UpdateConsultationUseCase(ConsultationEntity consultaMarcada, ConsultationEntity consultaAlterar)
        {
            _consultaMarcada = consultaMarcada;
            _consultaAlterar = consultaAlterar;
        }

        public ConsultationEntity VerificarAlteracao()
        {
            Assertion.AssertIsNotNull(_consultaMarcada, ConsultationValidationMessages.ConsultationNotFound);
            Assertion.AssertIsNotNull(_consultaAlterar, ConsultationValidationMessages.ConsultationNotFound);
            Assertion.AssertIfDateIsGreaterThanOrEquals(_consultaAlterar.Date, DateTime.Now, ConsultationValidationMessages.ConsultationDateHasPasses);

            if (DateTime.Compare(_consultaMarcada.Date, _consultaAlterar.Date) != 0)
                _consultaAlterar.SetStatus(ConsultationStatus.Reagendada);

            return _consultaAlterar;
        }
    }
}
