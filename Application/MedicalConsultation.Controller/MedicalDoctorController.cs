using MedicalConsultation.Entity.MedicalDoctor;
using MedicalConsultation.Interfaces.Controller;
using MedicalConsultation.Interfaces.Gateway;
using MedicalConsultation.UseCases.MedicalDoctor;

namespace MedicalConsultation.Controller
{
    public class MedicalDoctorController : IMedicalDoctorController
    {
        private readonly IMedicalDoctorGateway _doctorGateway;
        private readonly IConsultationGateway _consultationGateway;
        private readonly INotificationGateway _notificationsGateway;

        public MedicalDoctorController(IMedicalDoctorGateway doctorGateway,
            IConsultationGateway consultationGateway,
            INotificationGateway notificationsGateway)
        {
            _doctorGateway = doctorGateway;
            _consultationGateway = consultationGateway;
            _notificationsGateway = notificationsGateway;
        }

        public MedicalDoctorEntity Alterar(MedicalDoctorEntity entity)
        { 
            var registroBase = _doctorGateway.ObterPorId(entity.Id);
            MedicalDoctorEntity registroPorEmail = _doctorGateway.ObterPorEmail(entity.Usuario.Email);
            var useCase = new UpdateMedicalDoctorUseCase(entity, registroBase, registroPorEmail);

            useCase.VerificarExistente();

            registroBase.SetEspecialidade(entity.Especialidade);
            registroBase.SetCrm(entity.CRM);

            registroBase.Usuario.SetName(entity.Usuario.Name);
            registroBase.Usuario.SetCpf(entity.Usuario.CPF);
            registroBase.Usuario.SetEmail(entity.Usuario.Email);
            

            return _doctorGateway.AtualizarMedico(registroBase);
        }

        public MedicalDoctorEntity Incluir(MedicalDoctorEntity entity)
        {
            var registroBase = _doctorGateway.ObterPorEmail(entity.Usuario.Email);
            //var registroBase = _doctorGateway.ObterPorId(entity.Id);
            var useCase = new IncludeMedicalDoctorUseCase(entity, registroBase);

            var obj = useCase.VerificarExistente();
            
            if (obj.Id == 0)
                _doctorGateway.RegistrarMedico(obj);
            else
                _doctorGateway.AtualizarMedico(obj);//reativação do usuário

            return entity;
        }

        public IEnumerable<MedicalDoctorEntity> ListarAtivos()
        {
            return _doctorGateway.ObterAtivos();
        }

        public MedicalDoctorEntity ObterUsuarioPorEmail(string email)
        {
            return _doctorGateway.ObterPorEmail(email);
        }

        public MedicalDoctorEntity ObterUsuarioPorId(int id)
        {
            return _doctorGateway.ObterPorId(id);
        }
        public bool Excluir(int id)
        {
            var entity = _doctorGateway.ObterPorId(id);
            entity.SetAtivo(false);

            //atualizar cancelar consultas
            var consultasMedico = _consultationGateway.ListarConsultasMedicoAPartirDe(id, DateTime.Now)?.ToList();
            consultasMedico?.ForEach(c =>
            {
                if (c.Status != Entity.ConsultationStatus.Cancelada)
                {
                    c.SetStatus(Entity.ConsultationStatus.Cancelada);
                    _consultationGateway.AtualizarConsulta(c);
                    //enviar notificação
                    _notificationsGateway.SendNotification(
                        new Entity.Notify.ConsultationNotificationEntity(c, DateTime.Now));
                }
            });

            return _doctorGateway.AtualizarMedico(entity) != null;
        }

    }
}
