using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface INotificationRepository : IRepository<ConsultationNotificationEntity>
    {
        IEnumerable<ConsultationNotificationEntity> ConsultarPorDataNotificacao(DateTime data);
        IEnumerable<ConsultationNotificationEntity> ConsultarPorIdConsulta(int idConsulta);
        IEnumerable<ConsultationNotificationEntity> ConsultarPorIdConsultaNaData(int idConsulta, DateTime? data);
        ConsultationNotificationEntity Incluir(ConsultationNotificationEntity entity);
    }
}
