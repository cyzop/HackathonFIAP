namespace MedicalConsultation.Messages.UseCaseValidationMessages
{
    public static class MedicalDoctorValidationMessages
    {
        public static string MedicalDoctorNotFound 
            => "O médico informado não foi encontrado.";
        public static string MedicalDoctorAlreadyExistingWithSameEmail 
            => "Já existe um médico cadastrado para este email.";
        public static string MedicalDoctorAlreadyExistingWithSameCrm 
            => "Já existe um médico cadastrado para este crm.";
    }
}
