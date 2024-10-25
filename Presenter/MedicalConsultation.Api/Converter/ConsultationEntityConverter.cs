using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class ConsultationEntityConverter : IEntityConverter<ConsultationEntity, ConsultationDao>
    {
        private readonly IEntityConverter<MedicalDoctorEntity, MedicalDoctorDao> _medicalConverter;
        private readonly IEntityConverter<UserEntity, UserDao> _patientConverter;

        public ConsultationEntityConverter(
            IEntityConverter<MedicalDoctorEntity, MedicalDoctorDao> medicalConverter, 
            IEntityConverter<UserEntity, UserDao> patientConverter)
        {
            _medicalConverter = medicalConverter;
            _patientConverter = patientConverter;
        }

        public ConsultationDao Convert(ConsultationEntity entity)
        {
            return entity!=null ? new ConsultationDao() { 
                Id = entity.Id,
                Date = entity.Date,
                Status = entity.Status.GetDescription(),
                StatusDate = entity.DataStatus,
                MedicalId = entity.MedicoId,
                PatientId = entity.PacienteId,

                MedicalDoctor = entity.Medico!=null ? _medicalConverter.Convert(entity.Medico) : null,
                Patient = entity.Paciente!=null ? _patientConverter.Convert(entity.Paciente) : null

            } : null;
        }
    }
}
