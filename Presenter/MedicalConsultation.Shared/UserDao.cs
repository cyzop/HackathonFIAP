namespace MedicalConsultation.Shared
{
    public class UserDao : PatientDao
    {
        public bool EhMedico { get; set; } = false;
    }
}
