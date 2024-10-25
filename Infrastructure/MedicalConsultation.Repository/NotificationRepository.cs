using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        protected ApplicationDbContext _context;
        protected DbSet<ConsultationNotificationEntity> _dbSet;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ConsultationNotificationEntity>();
        }

        public void Incluir(ConsultationNotificationEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<ConsultationNotificationEntity> ConsultarPorIdConsulta(int idConsulta)
        {
            return _context.Notificacoes
                         .Where(e => e.ConsultaId == idConsulta)
                         .Include(c => c.Consulta)
                         .Include(c => c.Consulta.Medico)
                         .Include(c => c.Consulta.Medico.Usuario)
                         .Include(c => c.Consulta.Paciente)
                         .ToList();
        }

        public void Alterar(ConsultationNotificationEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public ConsultationNotificationEntity ConsultarPorId(int id)
        {
            return _context.Notificacoes
                        .Where(e => e.Id == id)
                        .Include(c => c.Consulta)
                        .Include(c => c.Consulta.Medico)
                        .Include(c => c.Consulta.Medico.Usuario)
                        .Include(c => c.Consulta.Paciente)
                        .FirstOrDefault();
        }

        public ICollection<ConsultationNotificationEntity> ConsultarAtivos()
        {
            return _context.Notificacoes.ToList();
        }
    }
}
