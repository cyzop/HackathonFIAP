using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Repository
{
    public class ConsultationRepository : EFRepository<ConsultationEntity>, IConsultationRepository
    {
        public ConsultationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedico(int id)
        {
            return _context.Consultas.Where(c => c.MedicoId == id)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedicoNoStatus(int id, ConsultationStatus status)
        {
            return _context.Consultas.Where(c => c.MedicoId == id &&
                c.Status == status)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedicoNaData(int id, DateTime data)
        {
            return _context.Consultas.Where(c => c.MedicoId == id && c.Date == data)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorPaciente(int id)
        {
            return _context.Consultas.Where(c => c.PacienteId == id)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorPacienteNoStatus(int id, ConsultationStatus status)
        {
            return _context.Consultas.Where(c => c.PacienteId == id &&
                c.Status == status)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedicoAPartirDe(int medicoId, DateTime dataInicio)
        {
            return _context.Consultas.Where(c => c.MedicoId == medicoId &&
               c.Date >= dataInicio)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorPacienteAPartirDe(int pacienteId, DateTime dataInicio)
        {
            return _context.Consultas.Where(c => c.PacienteId == pacienteId &&
             c.Date >= dataInicio)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorPacienteNoPeriodo(int pacienteId, DateTime? horarioInicio, DateTime? horarioFim)
        {
            var consultas = from c in _context.Consultas
                           where    c.PacienteId == pacienteId 
                           select c;

            if(horarioInicio.HasValue)
                consultas = consultas.Where(c=>c.Date >= horarioInicio.Value);

            if (horarioFim.HasValue)
                consultas = consultas.Where(c => c.Date <= horarioFim.Value);

            return consultas?.ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedicoNoPeriodo(int medicoId, DateTime? horarioInicio, DateTime? horarioFim)
        {
            var consultas = from c in _context.Consultas
                            where c.MedicoId == medicoId
                            select c;

            if (horarioInicio.HasValue)
                consultas = consultas.Where(c => c.Date >= horarioInicio.Value);

            if (horarioFim.HasValue)
                consultas = consultas.Where(c => c.Date <= horarioFim.Value);

            return consultas?.ToList();
        }
    }
}
