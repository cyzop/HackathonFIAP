using MedicalConsultation.Entity;
using MedicalConsultation.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.Repository
{
    public class EFRepository<T> : IRepository<T> where T : BasicEntity
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual void Alterar(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public virtual ICollection<T> ConsultarAtivos() 
            => _dbSet.Where(e => e.Ativo).ToList();

        public virtual T ConsultarPorId(int id)
          => _dbSet.FirstOrDefault(e => e.Id == id);

        public virtual void Incluir(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Remover(int id)
        {
            var entity = ConsultarPorId(id);
            entity.SetAtivo(false);
            Alterar(entity);
        }
    }
}
