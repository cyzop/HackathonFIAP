using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface IConsultationRepository : IRepository<ConsultationEntity>
    {
        IEnumerable<ConsultationEntity> ConsultarPorPaciente(int id);
        IEnumerable<ConsultationEntity> ConsultarPorPacienteNoStatus(int id, ConsultationStatus status);
        IEnumerable<ConsultationEntity> ConsultarPorMedico(int id);
        IEnumerable<ConsultationEntity> ConsultarPorMedicoNoStatus(int id, ConsultationStatus status);

        IEnumerable<ConsultationEntity> ConsultarPorMedicoNaData(int id, DateTime date);
        IEnumerable<ConsultationEntity> ConsultarPorMedicoAPartirDe(int medicoId, DateTime dataInicio);
        IEnumerable<ConsultationEntity> ConsultarPorPacienteAPartirDe(int pacienteId, DateTime dataInicio);
        IEnumerable<ConsultationEntity> ConsultarPorMedicoNoPeriodo(int medicoId, DateTime? horarioInicio, DateTime? horarioFim);
        IEnumerable<ConsultationEntity> ConsultarPorPacienteNoPeriodo(int pacienteId, DateTime? horarioInicio, DateTime? horarioFim);
        IEnumerable<ConsultationEntity> ConsultarPorData(DateTime diaConsulta);
    }
}
