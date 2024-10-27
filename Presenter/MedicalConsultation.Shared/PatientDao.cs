namespace MedicalConsultation.Shared
{
    public class PatientDao : Dao
    {
        public string Email { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}
