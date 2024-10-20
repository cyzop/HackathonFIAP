using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class ConsultationEntityConverter : IEntityConverter<ConsultationEntity, ConsultationDao>
    {
        public ConsultationDao Convert(ConsultationEntity entity)
        {
            return new ConsultationDao() { 
                Id = entity.Id,
                Date = entity.Date,
                Status = entity.Status.GetDescription(),
                StatusDate = entity.DataStatus,
                MedicalId = entity.MedicoId,
                PatientId = entity.PacienteId
            };
        }
    }
}
