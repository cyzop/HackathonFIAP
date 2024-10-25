using MedicalConsultation.Entity.Notify;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface INotificationRepository : IRepository<ConsultationNotificationEntity>
    {
        public ICollection<ConsultationNotificationEntity> ConsultarPorIdConsulta(int idConsulta);
        public ICollection<ConsultationNotificationEntity> ConsultarPorIdConsultaNaData(int idConsulta, DateTime? data);
        public void Incluir(ConsultationNotificationEntity entity);
    }
}
