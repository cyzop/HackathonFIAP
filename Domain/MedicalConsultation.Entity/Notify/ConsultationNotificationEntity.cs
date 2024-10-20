using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.Notify
{
    public class ConsultationNotificationEntity : Entity
    {
        public ConsultationNotificationEntity(int id, bool ativo = true) : base(id, ativo) 
        {
        }

        public ConsultationNotificationEntity(ConsultationEntity consulta, DateTime data)
        {
            Consulta = consulta;
            ConsultaId = consulta.Id;
            Data = data;
        }

        public DateTime Data { get; private set; }
        public int ConsultaId { get;set; }
        public virtual ConsultationEntity Consulta { get; set; }

        public void SetDate(DateTime date)
            => Data = date;

        public override void Validate()
        {
            var idconsulta = ConsultaId>0 ? ConsultaId : Consulta?.Id;
            var idpaciente = Consulta?.PacienteId > 0 ? Consulta?.PacienteId : Consulta?.Paciente?.Id;
            Assertion.AssertMinValue(idconsulta, 1, NotificationValidationMessages.ConsultationCannotBeIsNullOrEmpty);
            Assertion.AssertMinValue(idpaciente, 1, NotificationValidationMessages.PatientCannotBeIsNullOrEmpty);
        }
    }
}
