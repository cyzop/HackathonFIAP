namespace MedicalConsultation.Messages.EntityValidationMessages
{
    public static class MedicalDoctorValidationMessages
    {
        public static string NameCannotBeIsNullOrEmpty 
            => "O nome do médico é obrigatório.";
        public static string CRMCannotBeIsNullOrEmpty 
            => "O CRM do médico é obrigatório.";
        public static string EmailCannotBeIsNullOrEmpty 
            => "O Email do médico é obrigatório.";
    }
}
