namespace MedicalConsultation.Shared
{
    public class MedicalDoctorDao : Dao
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Crm { get; set; }
        public string Especialidade { get; set; }
    }
}
