namespace MedicalConsultation.Messages.UseCaseValidationMessages
{
    public static class ConsultationValidationMessages
    {
        public static string MedicalDoctorWithConsultationAtTheSameTime
           => "O médico já possui uma consulta marcada para a mesma data e horário.";

        public static string PatientWithConsultationAtTheSameTime
           => "O paciente já possui uma consulta marcada para a mesma data e horário.";
    }
}
