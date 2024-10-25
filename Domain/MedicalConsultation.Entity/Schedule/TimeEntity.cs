namespace MedicalConsultation.Entity.Schedule
{
    public class TimeEntity : BasicEntity
    {
        public DayOfWeek DiaDaSemana { get; 
            private set; }
        public TimeSpan Hora { get; 
            private set; }

        public TimeEntity(int id, TimeSpan hora, DayOfWeek diaDaSemana) : base(id, true)
        {
            Hora = hora;
            DiaDaSemana = diaDaSemana;
        }

        public TimeEntity()
        {
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
