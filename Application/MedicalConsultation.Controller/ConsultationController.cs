using MedicalConsultation.Entity.Consultation;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.UseCases.Consultation;

namespace MedicalConsultation.Controller
{
    public class ConsultationController : IConsultationController
    {
        private readonly IConsultationGateway _consultationGateway;
        private readonly IMedicalDoctorGateway _medicalDoctorGateway;
        private readonly IUserGateway _userGateway;

        public ConsultationController(IConsultationGateway consultationGateway, IUserGateway userGateway, IMedicalDoctorGateway medicalDoctorGateway)
        {
            _consultationGateway = consultationGateway;
            _userGateway = userGateway;
            _medicalDoctorGateway = medicalDoctorGateway;
        }

        public ConsultationEntity Alterar(ConsultationEntity entity)
        {
            var consulta = _consultationGateway.ObterPorId(entity.Id);
            if(consulta != null)
            {
                var useCase = new UpdateConsultationUseCase(consulta, entity);
                var alterar = useCase.VerificarAlteracao();
                if (alterar != null)
                {
                    _consultationGateway.AtualizarConsulta(alterar);
                    return alterar;
                }
            }
            return entity;
        }

        public bool Cancelar(int idConsulta)
        {
            var consulta = _consultationGateway.ObterPorId(idConsulta);
            if(consulta != null)
            {
                var useCase = new CancelConsultationUseCase(consulta);
                var cancelamento = useCase.VerificarCancelamento();
                if (cancelamento != null)
                    _consultationGateway.AtualizarConsulta(cancelamento);
            }
            return true;
        }

        public ConsultationEntity Incluir(ConsultationEntity entity)
        {
            var paciente = _userGateway.ObterPorId(entity.PacienteId);
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

        public ConsultationEntity ListarPorId(int idConsulta)
        {
            return _consultationGateway.ObterPorId(idConsulta);
        }

        public IEnumerable<ConsultationEntity> ListarPorMedico(string email)
        {
            var medico = _medicalDoctorGateway.ObterPorEmail(email);
            if (medico != null)
                return _consultationGateway.ListarConsultasMedicoAPartirDe(medico.Id, DateTime.Now)?.ToList();
            else
                return null;
        }

        public IEnumerable<ConsultationEntity> ListarPorMedicoAPartirDe(string email, DateTime data)
        {
            var medico = _medicalDoctorGateway.ObterPorEmail(email);
            if (medico != null)
                return _consultationGateway.ListarConsultasMedicoAPartirDe(medico.Id, data)?.ToList();
            else
                return null;
        }

        public IEnumerable<ConsultationEntity> ListarPorPaciente(string email)
        {
            var paciente = _userGateway.ObterPorEmail(email);
            if (paciente != null)
                return _consultationGateway.ListarConsultasPacienteAPartirDe(paciente.Id, DateTime.Now).ToList();
            else
                return null;
        }

        public IEnumerable<ConsultationEntity> ListarPorPacienteAPartirDe(string email, DateTime data)
        {
            var paciente = _userGateway.ObterPorEmail(email);
            if (paciente != null)
                return _consultationGateway.ListarConsultasPacienteAPartirDe(paciente.Id, data).ToList();
            else
                return null;
        }
    }
}
