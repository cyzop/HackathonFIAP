using MedicalConsultation.Entity.MedicalDoctor;

namespace MedicalConsultation.Interfaces.Gateway
{
    public interface IMedicalDoctorGateway
    {
        MedicalDoctorEntity ObterPorEmail(string email);
        MedicalDoctorEntity ObterPorId(int id);
        List<MedicalDoctorEntity> ObterMedicos ();
        void RegistrarMedico(MedicalDoctorEntity medico);
        MedicalDoctorEntity AtualizarMedico(MedicalDoctorEntity medico);
        List<MedicalDoctorEntity> ObterAtivos();
    }
}
