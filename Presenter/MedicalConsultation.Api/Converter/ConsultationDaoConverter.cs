using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class ConsultationDaoConverter : IDaoConverter<ConsultationDao, ConsultationEntity>
    {
        public ConsultationEntity Convert(ConsultationDao dao)
        {
            ConsultationStatus consultationStatus = string.IsNullOrEmpty(dao.Status) ? 
                                                    ConsultationStatus.Agendada : 
                                                    (ConsultationStatus) Enum.Parse(typeof(ConsultationStatus), dao.Status);
            
            return new ConsultationEntity(
                dao.Id, 
                dao.PatientId, 
                dao.MedicalId,
                dao.Date, 
                consultationStatus,
                dao.StatusDate.HasValue ? dao.StatusDate : DateTime.Now);
        }
    }
}
