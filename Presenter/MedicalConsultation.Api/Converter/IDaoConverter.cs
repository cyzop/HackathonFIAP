using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public interface IDaoConverter<I, O> where I : Dao where O : Entity.Entity
    {
        public O Convert(I dao);
    }
}
