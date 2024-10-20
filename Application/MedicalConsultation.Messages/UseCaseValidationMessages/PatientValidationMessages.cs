namespace MedicalConsultation.Messages.UseCaseValidationMessages
{
    public static class PatientValidationMessages
    {
        public static string PatientAlreadyExistingWithSameEmail 
            => "Já existe um usuário cadastrado para este email";
        public static string PatientNotFound 
            => "O paciente informado não foi encontrado.";

    }
}
