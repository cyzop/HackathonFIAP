using System.ComponentModel.DataAnnotations;

namespace MedicalConsultation.Shared
{
    public class PatientDao : Dao
    {
        [Required (ErrorMessage ="Informe o Email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o CPF")]
        [CustomValidationCPF(ErrorMessage ="CPF Inválido")]
        public string cpf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o Nome")]
        public string Name { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}
