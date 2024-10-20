using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Entity.Schedule;

namespace MedicalConsultation.Interfaces.Controller
{
    public interface IMedicalDoctorController
    {
        MedicalDoctorEntity Incluir(MedicalDoctorEntity entity);
        MedicalDoctorEntity Alterar(MedicalDoctorEntity entity);
        MedicalDoctorEntity ObterUsuarioPorEmail(string email);
        MedicalDoctorEntity ObterUsuarioPorId(int id);
        IEnumerable<MedicalDoctorEntity> ListarAtivos();
        bool Excluir(int id);
    }
}
