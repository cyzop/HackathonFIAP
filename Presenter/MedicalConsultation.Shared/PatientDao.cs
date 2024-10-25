namespace MedicalConsultation.Shared
{
    public class PatientDao : Dao
    {
        public string Email { get; set;}
        public string cpf { get; set; }
        public string Name { get; set; }
        public bool Ativo { get; set; }
    }
}
