using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.Consultation
{
    public class ConsultationEntity : BasicEntity
    {
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Date { get; set; }
        public ConsultationStatus Status
        {
            get;
            set;
        }
        public DateTime? DataStatus
        {
            get;
            set;
        }
        public virtual UserEntity Paciente { get; set; }
        public virtual MedicalDoctorEntity Medico { get; set; }

        public void SetStatus(ConsultationStatus status)
        {
            Status = status;
            DataStatus = DateTime.Now;
        }

        public ConsultationEntity():base()
        {
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
        public ConsultationEntity(int pacienteId, int medicoId, DateTime date, ConsultationStatus status, DateTime? dataStatus): base()
        {
            PacienteId = pacienteId;
            MedicoId = medicoId;
            Date = date;
            Status = status;
            DataStatus = dataStatus;

            Validate();
        }

        public ConsultationEntity(int id, UserEntity paciente, MedicalDoctorEntity medico, DateTime date, ConsultationStatus status, DateTime? dataStatus) : base(id)
        {
            Paciente = paciente;
            Medico = medico;
            Date = date;
            Status = status;
            DataStatus = dataStatus;

            Validate();
        }

        public ConsultationEntity(UserEntity paciente, MedicalDoctorEntity medico, DateTime date, ConsultationStatus status, DateTime? dataStatus) : this(paciente.Id, medico.Id, date, status, dataStatus)
        {
            Paciente = paciente;
            Medico = medico;

            Validate();
        }

        public override void Validate()
        {
            var idpaciente = PacienteId>0 ? PacienteId : Paciente?.Id;
            var idmedico = MedicoId > 0 ? MedicoId : Medico?.Id;
            Assertion.AssertGreatThanValuee(idpaciente, 0, ConsultationValidationMessages.PatientCannotBeNullOrEmpty);
            Assertion.AssertGreatThanValuee(idmedico, 0, ConsultationValidationMessages.MedicalDoctorCannotBeNullOrEmpty);
            Assertion.AssertDateIsNullOrInvalid(Date, ConsultationValidationMessages.DateCannotBeNullOrEmpty);
        }
    }
}
