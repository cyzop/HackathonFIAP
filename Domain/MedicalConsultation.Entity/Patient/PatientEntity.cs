using MedicalConsultation.Messages.Entity;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.Patient
{
    public class PatientEntity : PersonEntity
    {
        public string Cpf { get; private set; }

        public PatientEntity(int id, string name, string email, string cpf) : base(id, name, email)
        {
            Cpf = cpf;
            Validate();
        }

        public void SetCpf(string cpf)
            => Cpf = cpf;

        public override void Validate()
        {
            Assertion.AssertStringIsNotNullOrEmpty(base.Name, PatientValidationMessages.NameCannotBeIsNullOrEmpty);
            Assertion.AssertStringIsNotNullOrEmpty(base.Email, PatientValidationMessages.EmailCannotBeIsNullOrEmpty);
            Assertion.AssertStringIsNotNullOrEmpty(this.Cpf.ToString(), PatientValidationMessages.CPFCannotBeIsNullOrEmpty);

            //Max lenght 150
            Assertion.AssertMaxValue(base.Name.Length, 150, PatientValidationMessages.NameGreaterThanLimit(150));
        }

    }
}
