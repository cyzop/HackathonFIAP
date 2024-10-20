namespace MedicalConsultation.Shared
{
    public class MedicalDoctorScheduleDao
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int MedicalDoctorId { get; set; }
    }
}
