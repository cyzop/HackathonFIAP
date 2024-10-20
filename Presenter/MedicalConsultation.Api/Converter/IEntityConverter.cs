using MedicalConsultation.Shared;

namespace MedicalConsultation.Api.Converter
{
    public interface IEntityConverter<I, O> where I : Entity.Entity where O : Dao
    {
        public O Convert(I entity);
    }
}
