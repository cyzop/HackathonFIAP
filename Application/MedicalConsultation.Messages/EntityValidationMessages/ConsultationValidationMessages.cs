namespace MedicalConsultation.Messages.EntityValidationMessages
{
    public static class ConsultationValidationMessages
    {
        public static string PatientCannotBeIsNullOrEmpty 
            => "O paciente é obrigatório.";
        public static string MedicalDoctorCannotBeIsNullOrEmpty 
            => "O médico é obrigatório.";
        public static string DateCannotBeIsNullOrEmpty 
            => "A dada da consulta é obrigatória.";
    }
}
