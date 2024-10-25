using MedicalConsultation.Entity;
using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Gateways
{
    public class ConsultationGateway : IConsultationGateway
    {
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationGateway(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public ConsultationEntity AtualizarConsulta(ConsultationEntity consulta)
        {
            _consultationRepository.Alterar(consulta);
            return consulta;
        }

        public void IncluirConsulta(ConsultationEntity consulta)
        {
            _consultationRepository.Incluir(consulta);
        }

        public IEnumerable<ConsultationEntity> ListarConsultasMedicoAPartirDe(int medicoId, DateTime dataInicio)
        {
            return _consultationRepository.ConsultarPorMedicoAPartirDe(medicoId, dataInicio);
        }

        public IEnumerable<ConsultationEntity> ListarConsultasMedico(int medicoId, DateTime data)
        {
            return _consultationRepository.ConsultarPorMedicoNaData(medicoId, data);
        }
        public IEnumerable<ConsultationEntity> ListarConsultasMedico(int medicoId)
        {
            return _consultationRepository.ConsultarPorMedico(medicoId);
        }

        public IEnumerable<ConsultationEntity> ListarConsultasMedicoNoStatus(int medicoId, ConsultationStatus status)
        {
            return _consultationRepository.ConsultarPorMedicoNoStatus(medicoId, status);
        }

        public IEnumerable<ConsultationEntity> ListarConsultasPaciente(int pacienteId)
        {
            return _consultationRepository.ConsultarPorPaciente(pacienteId);
        }

        public IEnumerable<ConsultationEntity> ListarConsultasPacienteAPartirDe(int medicoId, DateTime dataInicio)
        {
            return _consultationRepository.ConsultarPorPacienteAPartirDe(medicoId, dataInicio);
        }

        public IEnumerable<ConsultationEntity> ObterConsultasPacienteNoPeriodo(int pacienteId, DateTime horarioInicio, DateTime horarioFim)
        {
            return _consultationRepository.ConsultarPorPacienteNoPeriodo(pacienteId, horarioInicio, horarioFim);
        }

        public IEnumerable<ConsultationEntity> ObterConsultasMedicoNoPeriodo(int medicoId, DateTime horarioInicio, DateTime horarioFim)
        {
            return _consultationRepository.ConsultarPorMedicoNoPeriodo(medicoId, horarioInicio, horarioFim);
        }

        public ConsultationEntity ObterPorId(int idConsulta)
        {
            return _consultationRepository.ConsultarPorId(idConsulta);
        }
    }
}
