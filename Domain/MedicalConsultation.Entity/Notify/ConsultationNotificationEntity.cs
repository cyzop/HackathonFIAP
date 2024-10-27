using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.Notify
{
    public class ConsultationNotificationEntity : BasicEntity
    {
        public string Message { get; set; }
        public ConsultationStatus StatusConsulta { get; set; }

        public ConsultationNotificationEntity():base()
        {
        }

        public ConsultationNotificationEntity(int id, bool ativo = true) : base(id)
        {
        }

        public ConsultationNotificationEntity(int id, ConsultationEntity consulta, DateTime data, bool ativo = true) : base(id)
        {
            Consulta = consulta;
            Data = data;
            if (consulta != null)
            {
                ConsultaId = consulta.Id;
                StatusConsulta = consulta.Status;
            }
            
            Validate();
        }

        public ConsultationNotificationEntity(ConsultationEntity consulta, DateTime data)
        {
            Consulta = consulta;
            Data = data;
            if (consulta != null)
            {
                ConsultaId = consulta.Id;
                StatusConsulta = consulta.Status;
            }

            Validate();
        }

        public DateTime Data { get; set; }
        public int ConsultaId { get; set; }
        public virtual ConsultationEntity Consulta { get; set; }

        public void SetMessage(string message)
            => Message = message;

        public override void Validate()
        {
            var idconsulta = ConsultaId>0 ? ConsultaId : Consulta?.Id;
            var idpaciente = Consulta?.PacienteId > 0 ? Consulta?.PacienteId : Consulta?.Paciente?.Id;
            Assertion.AssertGreatThanValuee(idconsulta, 0, NotificationValidationMessages.ConsultationCannotBeNullOrEmpty);
            Assertion.AssertGreatThanValuee(idpaciente, 0, NotificationValidationMessages.PatientCannotBeNullOrEmpty);
        }
    }
}
