using MedicalConsultation.Messages.EntityValidationMessages;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.MedicalDoctor
{
    public class MedicalDoctorEntity : PersonEntity
    {
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

        public MedicalDoctorEntity(int id, string name, string email, string cRM, string especialidade, bool ativo) : base(id, name, email, ativo)
        {
            CRM = cRM;
            Especialidade = especialidade;
            Validate();
        }

        public MedicalDoctorEntity(int id, string name, string email, string cRM, string especialidade) : base(id, name, email)
        {
            CRM = cRM;
            Especialidade = especialidade;
            Validate();
        }

        public override void Validate()
        {
            Assertion.AssertStringIsNotNullOrEmpty(base.Name, MedicalDoctorValidationMessages.NameCannotBeIsNullOrEmpty);
            Assertion.AssertStringIsNotNullOrEmpty(base.Email, MedicalDoctorValidationMessages.EmailCannotBeIsNullOrEmpty);
            Assertion.AssertStringIsNotNullOrEmpty(this.CRM, MedicalDoctorValidationMessages.CRMCannotBeIsNullOrEmpty);
        }
    }
}
