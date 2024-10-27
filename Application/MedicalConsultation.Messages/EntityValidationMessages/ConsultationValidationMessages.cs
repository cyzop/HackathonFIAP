namespace MedicalConsultation.Messages.EntityValidationMessages
{
    public static class ConsultationValidationMessages
    {
        public static string PatientCannotBeNullOrEmpty 
            => "O paciente é obrigatório.";
        public static string MedicalDoctorCannotBeNullOrEmpty 
            => "O médico é obrigatório.";
        public static string DateCannotBeNullOrEmpty 
            => "A dada da consulta é obrigatória.";
    }
}
