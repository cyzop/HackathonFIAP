namespace MedicalConsultation.Messages.Entity
{
    public static class PatientValidationMessages
    {
        public static string NameCannotBeNullOrEmpty 
            => "O nome do paciente é obrigatório.";

        public static string EmailCannotBeNullOrEmpty 
            => "O email do paciente é obrigatório";

        public static string CPFCannotBeNullOrEmpty 
            => "O CPF do paciente é obrigatório";

        public static string NameGreaterThanLimit(int value) 
            => $"O nome do paciente não pode ser maior que {value} posições.";

    }
}
