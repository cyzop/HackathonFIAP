using MedicalConsultation.Entity.Schedule;
using MedicalConsultation.Interfaces.Repository;

namespace MedicalConsultation.Repository
{
    public class TimeRepository : EFRepository<TimeEntity>, ITimeRepository
    {
        public TimeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
