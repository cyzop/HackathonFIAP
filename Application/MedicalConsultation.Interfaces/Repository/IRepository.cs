namespace MedicalConsultation.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity.Entity
    {
        abstract void Alterar(T entity);
        void Incluir (T entity);
        T ConsultarPorId(int id);
        ICollection<T> ConsultarAtivos();

    }
}
