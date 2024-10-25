using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Gateways
{
    public class MedicalDoctorGateway : IMedicalDoctorGateway
    {
        private readonly IMedicalDoctorRepository _medicalDoctorRepository;

        public MedicalDoctorGateway(IMedicalDoctorRepository medicalDoctorRepository)
        {
            _medicalDoctorRepository = medicalDoctorRepository;
        }

        public MedicalDoctorEntity AtualizarMedico(MedicalDoctorEntity medico)
        {
            _medicalDoctorRepository.Alterar(medico);
            return medico;
        }

        public List<MedicalDoctorEntity> ObterMedicos()
        {
            return _medicalDoctorRepository.ConsultarAtivos()?.ToList();
        }

        public MedicalDoctorEntity ObterPorEmail(string email)
        {
            return _medicalDoctorRepository.ConsultarPorEmail(email);
        }
        public MedicalDoctorEntity ObterPorId(int id)
        {
            return _medicalDoctorRepository.ConsultarPorId(id);
        }

        public void RegistrarMedico(MedicalDoctorEntity medico)
        {
            _medicalDoctorRepository.Incluir(medico);
        }

        public List<MedicalDoctorEntity> ObterAtivos()
        {
            return _medicalDoctorRepository.ConsultarAtivos()?.ToList();
        }
    }
}
