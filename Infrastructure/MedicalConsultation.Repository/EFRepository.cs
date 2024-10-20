using MedicalConsultation.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.Repository
{
    public class EFRepository<T> : IRepository<T> where T : Entity.Entity
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Alterar(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public ICollection<T> ConsultarAtivos() 
            => _dbSet.Where(e => e.Ativo).ToList();

        public T ConsultarPorId(int id)
          => _dbSet.FirstOrDefault(e => e.Id == id);

        public void Incluir(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var entity = ConsultarPorId(id);
            entity.SetAtivo(false);
            Alterar(entity);
        }
    }
}
