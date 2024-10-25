using MedicalConsultation.Entity.Consultation;

namespace MedicalConsultation.Interfaces.Controller
{
    public interface IConsultationController
    {
        IEnumerable<ConsultationEntity> ListarPorPaciente(string email);
        IEnumerable<ConsultationEntity> ListarPorPacienteAPartirDe(string email, DateTime data);
        IEnumerable<ConsultationEntity> ListarPorMedico(string email);
        IEnumerable<ConsultationEntity> ListarPorMedicoAPartirDe(string email, DateTime data);
        ConsultationEntity Incluir(ConsultationEntity entity);
        ConsultationEntity Alterar(ConsultationEntity entity);
        bool Cancelar(int idConsulta);

        ConsultationEntity ListarPorId(int idConsulta);
    }
}
