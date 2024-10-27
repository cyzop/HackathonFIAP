namespace MedicalConsultation.Messages.EntityValidationMessages
{
    public static class NotificationValidationMessages
    {
        public static string ConsultationCannotBeNullOrEmpty 
            => "A consulta não pode estar vazia.";
        public static string PatientCannotBeNullOrEmpty 
            => "O paciente da consulta é obrigatório.";
    }
}
