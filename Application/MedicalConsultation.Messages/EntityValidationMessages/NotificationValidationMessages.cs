namespace MedicalConsultation.Messages.EntityValidationMessages
{
    public static class NotificationValidationMessages
    {
        public static string ConsultationCannotBeIsNullOrEmpty 
            => "A consulta não pode estar vazia.";
        public static string PatientCannotBeIsNullOrEmpty 
            => "O paciente da consulta é obrigatório.";
    }
}
