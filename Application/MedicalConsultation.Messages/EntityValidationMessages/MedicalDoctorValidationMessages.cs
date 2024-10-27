namespace MedicalConsultation.Messages.EntityValidationMessages
{
    public static class MedicalDoctorValidationMessages
    {
        public static string NameCannotBeNullOrEmpty 
            => "O nome do médico é obrigatório.";
        public static string CRMCannotBeNullOrEmpty 
            => "O CRM do médico é obrigatório.";
        public static string EmailCannotBeNullOrEmpty 
            => "O Email do médico é obrigatório.";
    }
}
