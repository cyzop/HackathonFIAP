using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace MedicalConsultation.Repository
{
    public class ConsultationRepository : EFRepository<ConsultationEntity>, IConsultationRepository
    {
        public ConsultationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override ConsultationEntity ConsultarPorId(int id)
        {
            return _context.Consultas
                .Where(c => c.Id == id)
                .Include(c => c.Medico)
                        .Include(c => c.Medico.Usuario)
                .Include(c=>c.Paciente)
                        .FirstOrDefault();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedico(int id)
        {
            return _context.Consultas
                .Where(c => c.MedicoId == id)?
                .Include(c => c.Paciente)
                .Where(c => c.Paciente.Ativo)
                .ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedicoNoStatus(int id, ConsultationStatus status)
        {
            return _context.Consultas
                .Where(c => c.MedicoId == id && c.Status == status)?
                .Include(c => c.Paciente)
                .Where(c => c.Paciente.Ativo)
                .ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedicoNaData(int id, DateTime data)
        {
            var retorno =  _context.Consultas
                            .Where(c => c.MedicoId == id && c.Date == data)?
                            .Include(c=>c.Paciente)
                            .Where(c=>c.Paciente.Ativo)
                            .ToList();  

            return retorno;
        }

        public IEnumerable<ConsultationEntity> ConsultarPorPaciente(int id)
        {
            return _context.Consultas
                                .Where(c => c.PacienteId == id)?
                                .Include(c => c.Medico)
                                .Include(c => c.Medico.Usuario)
                                .ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorPacienteNoStatus(int id, ConsultationStatus status)
        {
            return _context.Consultas
                            .Where(c => c.PacienteId == id && c.Status == status)?
                            .Include(c => c.Medico)
                            .Include(c => c.Medico.Usuario)
                            .ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorMedicoAPartirDe(int medicoId, DateTime dataInicio)
        {
            return _context.Consultas
                                .Where(c => c.MedicoId == medicoId &&c.Date >= dataInicio)?
                                .Include(c => c.Paciente)
                                .Where(c => c.Paciente.Ativo)
                                .ToList();
        }

        public IEnumerable<ConsultationEntity> ConsultarPorPacienteAPartirDe(int pacienteId, DateTime dataInicio)
        {
            return _context.Consultas
                            .Where(c => c.PacienteId == pacienteId && c.Date >= dataInicio)
                            .Include(c => c.Medico)
                            .Include(c => c.Medico.Usuario)
                            .ToList();
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

            return consultas
                        .Include(c => c.Medico)
                        .Include(c => c.Medico.Usuario)
                        .ToList();
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

        public IEnumerable<ConsultationEntity> ConsultarPorData(DateTime diaConsulta)
        {
            return _context.Consultas
                           .Where(c => c.Date.Date == diaConsulta.Date)
                           .Include(c => c.Medico)
                           .Include(c => c.Medico.Usuario)
                           .Include(c => c.Paciente)
                           .ToList();
        }
    }
}
