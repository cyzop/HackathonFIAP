using MedicalConsultation.Entity.Patient;

namespace MedicalConsultation.Interfaces.Gateway
{
    public interface IPatientGateway
    {
        PatientEntity ObterPorId(int id);
        PatientEntity ObterPorEmail(string email);
        List<PatientEntity> ObterAtivos();

        void Incluir(PatientEntity patient);
        PatientEntity Atualizar(PatientEntity patient);
    }

}
