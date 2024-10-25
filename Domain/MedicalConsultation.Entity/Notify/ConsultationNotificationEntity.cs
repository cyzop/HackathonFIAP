using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.Notify
{
    public class ConsultationNotificationEntity : BasicEntity
    {
        public string Message { get; private set; }
        public ConsultationNotificationEntity(int id, bool ativo = true) : base(id)
        {
        }

        public ConsultationNotificationEntity(ConsultationEntity consulta, DateTime data)
        {
            Consulta = consulta;
            ConsultaId = consulta.Id;
            Data = data;

            Validate();
        }

        public DateTime Data { get; private set; }
        public int ConsultaId { get;set; }
        public virtual ConsultationEntity Consulta { get; set; }

        public void SetDate(DateTime date)
            => Data = date;

        public void SetMessage(string message)
            => Message = message;

        public override void Validate()
        {
            var idconsulta = ConsultaId>0 ? ConsultaId : Consulta?.Id;
            var idpaciente = Consulta?.PacienteId > 0 ? Consulta?.PacienteId : Consulta?.Paciente?.Id;
            Assertion.AssertMinValue(idconsulta, 1, NotificationValidationMessages.ConsultationCannotBeIsNullOrEmpty);
            Assertion.AssertMinValue(idpaciente, 1, NotificationValidationMessages.PatientCannotBeIsNullOrEmpty);
        }
    }
}
