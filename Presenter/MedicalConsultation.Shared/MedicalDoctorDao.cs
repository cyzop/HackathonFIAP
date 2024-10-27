namespace MedicalConsultation.Shared
{
    public class MedicalDoctorDao : Dao
    {
        //public int Id { get; set; }
        public string email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Crm { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;
    }
}
