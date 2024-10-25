using MedicalConsultation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface IPersonRepository<T> where T: UserEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByEmailAsync(string email);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
