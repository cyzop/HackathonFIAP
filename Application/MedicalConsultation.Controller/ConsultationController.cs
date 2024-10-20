using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.UseCases.Consultation;
using MedicalConsultation.UseCases.Patient;

namespace MedicalConsultation.Controller
{
    public class ConsultationController : IConsultationController
    {
        private readonly IConsultationGateway _consultationGateway;
        private readonly IPatientGateway _patientGateway;
        private readonly IMedicalDoctorGateway _medicalDoctorGateway;

        public ConsultationController(IConsultationGateway consultationGateway, IPatientGateway patientGateway, IMedicalDoctorGateway medicalDoctorGateway)
        {
            _consultationGateway = consultationGateway;
            _patientGateway = patientGateway;
            _medicalDoctorGateway = medicalDoctorGateway;
        }

        public ConsultationEntity Alterar(ConsultationEntity entity)
        {
            return _consultationGateway.AtualizarConsulta(entity);
        }

        public ConsultationEntity Incluir(ConsultationEntity entity)
        {
            var paciente = _patientGateway.ObterPorId(entity.PacienteId);
            var medico = _medicalDoctorGateway.ObterPorId(entity.MedicoId);

            DateTime datahoraInicio = entity.Date;
            DateTime datahoraFim = entity.Date.AddMinutes(30);

            var consultasPaciente = _consultationGateway.ObterConsultasPacienteNoPeriodo(entity.PacienteId, datahoraInicio, datahoraFim);
            var consultasMedico = _consultationGateway.ObterConsultasMedicoNoPeriodo(entity.MedicoId, datahoraInicio, datahoraFim);

            var useCase = new IncludeConsultationUseCase(
                medico, 
                paciente, 
                consultasPaciente?.FirstOrDefault(), 
                consultasMedico?.FirstOrDefault(), 
                entity);

            var obj = useCase.VerificarExistente();

            _consultationGateway.IncluirConsulta(obj);

            return obj;
        }

        public IEnumerable<ConsultationEntity> ListarPorMedico(int id)
        {
            return _consultationGateway.ListarConsultasMedicoAPartirDe(id, DateTime.Now)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ListarPorMedicoAPartirDe(int id, DateTime data)
        {
            return _consultationGateway.ListarConsultasMedicoAPartirDe(id, data)?.ToList();
        }

        public IEnumerable<ConsultationEntity> ListarPorPaciente(int id)
        {
            return _consultationGateway.ListarConsultasPacienteAPartirDe(id, DateTime.Now).ToList();
        }

        public IEnumerable<ConsultationEntity> ListarPorPacienteAPartirDe(int id, DateTime data)
        {
            return _consultationGateway.ListarConsultasPacienteAPartirDe(id, data).ToList();
        }
    }
}
