using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public class PatientEntityConverter : IEntityConverter<PatientEntity, PatientDao>
    {
        public PatientDao Convert(PatientEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
