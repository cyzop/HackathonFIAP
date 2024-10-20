namespace MedicalConsultation.Messages.Entity
{
    public static class PatientValidationMessages
    {
        public static string NameCannotBeIsNullOrEmpty 
            => "O nome do paciente é obrigatório.";

        public static string EmailCannotBeIsNullOrEmpty 
            => "O email do paciente é obrigatório";

        public static string CPFCannotBeIsNullOrEmpty 
            => "O CPF do paciente é obrigatório";

        public static string NameGreaterThanLimit(int value) 
            => $"O nome do paciente não pode ser maior que {value} posições.";

        
    }
}
