using MedicalConsultation.Entity.Patient;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Gateways
{
    public class PatientGateway : IPatientGateway
    {
        private readonly IPatientRepository _patientRepository;

        public PatientGateway(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public PatientEntity Atualizar(PatientEntity patient)
        {
            _patientRepository.Alterar(patient);
            return patient;
        }

        public void Incluir(PatientEntity patient)
        {
            _patientRepository.Incluir(patient);
        }

        public List<PatientEntity> ObterAtivos()
        {
            return _patientRepository.ConsultarAtivos()?.ToList();
        }

        public PatientEntity ObterPorEmail(string email)
        {
            return _patientRepository.ConsultarPorEmail(email);
        }

        public PatientEntity ObterPorId(int id)
        {
            return _patientRepository.ConsultarPorId(id);
        }
    }
}
