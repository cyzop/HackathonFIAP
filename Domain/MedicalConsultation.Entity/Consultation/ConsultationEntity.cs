using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.Consultation
{
    public class ConsultationEntity : Entity
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Date { get; set; }
        public ConsultationStatus Status
        {
            get;
            private set;
        }
        public DateTime? DataStatus
        {
            get;
            private set;
        }
        public virtual PatientEntity Paciente { get; set; }
        public virtual MedicalDoctorEntity Medico { get; set; }

        public void SetStatus(ConsultationStatus status)
        {
            Status = status;
            DataStatus = DateTime.Now;
        }

        public ConsultationEntity(int id, int pacienteId, int medicoId, DateTime date, ConsultationStatus status, DateTime? dataStatus):base(id)
        {
            PacienteId = pacienteId;
            MedicoId = medicoId;
            Date = date;
            Status = status;
            DataStatus = dataStatus;

            Validate();
        }
        public ConsultationEntity(int pacienteId, int medicoId, DateTime date, ConsultationStatus status, DateTime? dataStatus)
        {
            PacienteId = pacienteId;
            MedicoId = medicoId;
            Date = date;
            Status = status;
            DataStatus = dataStatus;

            Validate();
        }

        public ConsultationEntity(int id, PatientEntity paciente, MedicalDoctorEntity medico, DateTime date, ConsultationStatus status, DateTime? dataStatus) : this(id, paciente.Id, medico.Id, date, status, dataStatus)
        {
            Paciente = paciente;
            Medico = medico;

            Validate();
        }

        public ConsultationEntity(PatientEntity paciente, MedicalDoctorEntity medico, DateTime date, ConsultationStatus status, DateTime? dataStatus) : this(paciente.Id, medico.Id, date, status, dataStatus)
        {
            Paciente = paciente;
            Medico = medico;

            Validate();
        }

        public override void Validate()
        {
            var idpaciente = PacienteId>0 ? PacienteId : Paciente?.Id;
            var idmedico = MedicoId > 0 ? MedicoId : Medico?.Id;
            Assertion.AssertMinValue(idpaciente, 1, ConsultationValidationMessages.PatientCannotBeIsNullOrEmpty);
            Assertion.AssertMinValue(idpaciente, 1, ConsultationValidationMessages.MedicalDoctorCannotBeIsNullOrEmpty);
            Assertion.AssertDataIsNullOrInvalid(Date, ConsultationValidationMessages.DateCannotBeIsNullOrEmpty);
        }
    }
}
