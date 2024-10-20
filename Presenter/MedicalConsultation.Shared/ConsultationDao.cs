namespace MedicalConsultation.Shared
{
    public class ConsultationDao : Dao
    {
        public DateTime Date { get; set; }
        public string? Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public int MedicalId { get; set; }
        public int PatientId { get; set; }
    }
}
