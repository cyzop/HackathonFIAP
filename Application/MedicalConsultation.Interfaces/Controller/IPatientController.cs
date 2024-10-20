using MedicalConsultation.Entity.Patient;

namespace MedicalConsultation.Interfaces.Controller
{
    public interface IPatientController
    {
        PatientEntity Incluir(PatientEntity entity);
        PatientEntity Alterar(PatientEntity entity);
        bool Excluir(int id);
        PatientEntity ObterUsuarioPorEmail(string email);
        PatientEntity ObterUsuarioPorId(int id);

        IEnumerable<PatientEntity> ListarAtivos();
    }
}
