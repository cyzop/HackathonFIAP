using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.MedicalDoctor
{
    public class MedicalDoctorEntity : Entity
    {
        public int Id { get; set; }

        public virtual UserEntity Usuario { get; set; }

        public string CRM { get; 
            private set; }
        public string Especialidade { get; 
            private set; }

        public void SetCrm(string crm)
            => CRM = crm;


        public void SetEspecialidade(string especialidade)
            => Especialidade = especialidade;

        public MedicalDoctorEntity() : base()
        {
        }

        public MedicalDoctorEntity(int id, string name, string cpf, string email, string cRM, string especialidade, bool ativo) 
        {
            Id = id;
            CRM = cRM;
            Especialidade = especialidade;
            Usuario = new UserEntity(id, name, cpf, email, ativo);
        
            Validate();
        }

        public MedicalDoctorEntity(int id, string name, string cpf, string email, string cRM, string especialidade) 
        {
            Id = id;
            CRM = cRM;
            Especialidade = especialidade;
            Usuario = new UserEntity(id, name, cpf, email);
            Validate();
        }

        public void Validate()
        {
            Assertion.AssertStringIsNotNullOrEmpty(this.Usuario?.Name, MedicalDoctorValidationMessages.NameCannotBeIsNullOrEmpty);
            Assertion.AssertStringIsNotNullOrEmpty(this.Usuario?.Email, MedicalDoctorValidationMessages.EmailCannotBeIsNullOrEmpty);
            Assertion.AssertStringIsNotNullOrEmpty(this.CRM, MedicalDoctorValidationMessages.CRMCannotBeIsNullOrEmpty);
        }

        public void SetAtivo(bool ativo)
        {
            this.Usuario.SetAtivo(ativo);
        }
    }
}
