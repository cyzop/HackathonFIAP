using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.Repository
{
    //public class MedicalDoctorRepository : EFRepository<MedicalDoctorEntity>, IMedicalDoctorRepository
    public class MedicalDoctorRepository : IMedicalDoctorRepository
    {
        protected ApplicationDbContext _context;
        protected DbSet<MedicalDoctorEntity> _dbSet;
        public MedicalDoctorRepository(ApplicationDbContext context)// : base(context)
        {
            _context = context;
            _dbSet = context.Set<MedicalDoctorEntity>();
        }

        public void Alterar(MedicalDoctorEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public ICollection<MedicalDoctorEntity> ConsultarAtivos()
        {
            var retorno = _dbSet.Where(e => e.Usuario.Ativo)
                    .Include(e => e.Usuario)
                    .ToList();
            return retorno;
        }

        public MedicalDoctorEntity ConsultarPorEmail(string email)
        {
            return _dbSet
                .Where(e => string.Equals(e.Usuario.Email.ToLower(), email.ToLower()))
                .FirstOrDefault();
        }

        public MedicalDoctorEntity ConsultarPorId(int id)
        {
            return _dbSet
                .Include(c=>c.Usuario)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Incluir(MedicalDoctorEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        //public MedicalDoctorEntity ConsultarPorEmail(string email)
        //{
        //    return _dbSet
        //        .Where(p => p .Email.ToLower() == email.ToLower())
        //        .FirstOrDefault();
        //}
    }
}
