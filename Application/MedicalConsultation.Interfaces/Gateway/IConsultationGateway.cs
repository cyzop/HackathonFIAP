using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;

namespace MedicalConsultation.Interfaces.Gateway
{
    public interface IConsultationGateway
    {
        IEnumerable<ConsultationEntity> ListarConsultasPaciente(int pacienteId);
        IEnumerable<ConsultationEntity> ListarConsultasPacienteAPartirDe(int medicoId, DateTime dataInicio);
        IEnumerable<ConsultationEntity> ListarConsultasMedico(int medicoId, DateTime data);
        IEnumerable<ConsultationEntity> ListarConsultasMedicoNoStatus(int medicoId, ConsultationStatus status);
        IEnumerable<ConsultationEntity> ListarConsultasMedicoAPartirDe(int medicoId, DateTime dataInicio);
        IEnumerable<ConsultationEntity> ObterConsultasPorData(DateTime data);
        void IncluirConsulta(ConsultationEntity consulta);
        ConsultationEntity AtualizarConsulta(ConsultationEntity consulta);
        IEnumerable<ConsultationEntity> ObterConsultasPacienteNoPeriodo(int pacienteId, DateTime horarioInicio, DateTime horarioFim);
        IEnumerable<ConsultationEntity> ObterConsultasMedicoNoPeriodo(int medicoId, DateTime horarioInicio, DateTime horarioFim);

        
        ConsultationEntity ObterPorId(int idConsulta);
    }
}
