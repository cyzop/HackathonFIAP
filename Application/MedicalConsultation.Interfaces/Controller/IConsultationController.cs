using MedicalConsultation.Entity.Consultation;

namespace MedicalConsultation.Interfaces.Controller
{
    public interface IConsultationController
    {
        IEnumerable<ConsultationEntity> ListarPorPaciente(int id);
        IEnumerable<ConsultationEntity> ListarPorPacienteAPartirDe(int id, DateTime data);
        IEnumerable<ConsultationEntity> ListarPorMedico(int id);
        IEnumerable<ConsultationEntity> ListarPorMedicoAPartirDe(int id, DateTime data);
        ConsultationEntity Incluir(ConsultationEntity entity);
        ConsultationEntity Alterar(ConsultationEntity entity);
    }
}
