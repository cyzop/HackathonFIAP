namespace MedicalConsultation.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity.Entity
    {
        abstract void Alterar(T entity);
        T Incluir (T entity);
        T ConsultarPorId(int id);
        IEnumerable<T> ConsultarAtivos();

    }
}
