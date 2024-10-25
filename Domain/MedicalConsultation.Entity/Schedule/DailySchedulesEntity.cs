namespace MedicalConsultation.Entity.Schedule
{
    public class DailySchedulesEntity : BasicEntity
    {
        public DayOfWeek DiaDaSemana { get; private set; }
        public virtual List<TimeEntity> Horarios { get; private set; }

        public DailySchedulesEntity()
        {
            Horarios = new List<TimeEntity>();
        }

        public DailySchedulesEntity(DayOfWeek diaDaSemana)
        {
            DiaDaSemana = diaDaSemana;
            Horarios = new List<TimeEntity>();
        }
        public void AddHorario(TimeEntity horario) => Horarios.Add(horario);

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
