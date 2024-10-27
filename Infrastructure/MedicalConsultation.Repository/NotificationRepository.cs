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

        public IEnumerable<ConsultationNotificationEntity> ConsultarPorIdConsulta(int idConsulta)
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

        public IEnumerable<ConsultationNotificationEntity> ConsultarAtivos()
        {
            return _context.Notificacoes.
                Where(n=>n.Ativo)
                .Include(c => c.Consulta)
                         .Include(c => c.Consulta.Medico)
                         .Include(c => c.Consulta.Medico.Usuario)
                         .Include(c => c.Consulta.Paciente)
                .ToList();
        }

        public IEnumerable<ConsultationNotificationEntity> ConsultarPorIdConsultaNaData(int idConsulta, DateTime? data)
        {
            var registros = from c in _context.Notificacoes
                            where c.ConsultaId == idConsulta
                            select c;

            if (data.HasValue)
                registros = registros.Where(c => c.Data >= data);

            return registros
                    .Include(c => c.Consulta)
                    .Include(c => c.Consulta.Medico)
                    .Include(c => c.Consulta.Medico.Usuario)
                    .Include(c => c.Consulta.Paciente)
                    .ToList();
        }

        public IEnumerable<ConsultationNotificationEntity> ConsultarPorDataNotificacao(DateTime data)
        {
            return _context.Notificacoes
                .Where(c => c.Data.Date == data.Date);
        }
    }
}
