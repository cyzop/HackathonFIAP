using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface INotificationRepository : IRepository<ConsultationNotificationEntity>
    {
        IEnumerable<ConsultationNotificationEntity> ConsultarPorDataNotificacao(DateTime data);
        IEnumerable<ConsultationNotificationEntity> ConsultarPorIdConsulta(int idConsulta);
        IEnumerable<ConsultationNotificationEntity> ConsultarPorIdConsultaNaData(int idConsulta, DateTime? data);
        public void Incluir(ConsultationNotificationEntity entity);
    }
}
