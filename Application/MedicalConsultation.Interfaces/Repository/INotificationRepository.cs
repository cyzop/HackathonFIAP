using MedicalConsultation.Entity.Notify;
using MedicalConsultation.Entity.Patient;

namespace MedicalConsultation.Interfaces.Repository
{
    public interface INotificationRepository : IRepository<ConsultationNotificationEntity>
    {
        public ICollection<ConsultationNotificationEntity> ConsultarPorIdConsulta(int idConsulta);
        public void Incluir(ConsultationNotificationEntity entity);
    }
}
