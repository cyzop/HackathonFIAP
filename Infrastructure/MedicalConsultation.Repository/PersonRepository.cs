using MedicalConsultation.Entity;
using MedicalConsultation.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.Repository
{
    public class PersonRepository<T> : IPersonRepository<T> where T : UserEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByEmailAsync(string email)
        {
            var x = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
            return x;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                entity.SetAtivo(false);
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
