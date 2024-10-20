namespace MedicalConsultation.Shared
{
    public class ScheduleDao
    {
        public int Id { get;set; }
        public DateTime Date { get; set; }

        public MedicalDoctorDao? MedicalDoctor { get; set; }
        public int? PatientId { get; set; }
    }
}
