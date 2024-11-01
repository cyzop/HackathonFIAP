﻿using MedicalConsultation.Messages.Entity;
using MedicalConsultation.Validations;

namespace MedicalConsultation.Entity.Patient
{
    public class PatientEntity : UserEntity
    {
        public PatientEntity(int id, string name, string CPF, string email) : base(id, name, CPF, email)
        {
            Validate();
        }

        public PatientEntity(int id, string name, string CPF, string email, bool ativo) : base(id, name, CPF, email, ativo)
        {
            Validate();
        }

        public override void Validate()
        {
            Assertion.AssertStringIsNotNullOrEmpty(base.Name, PatientValidationMessages.NameCannotBeNullOrEmpty);
            Assertion.AssertStringIsNotNullOrEmpty(base.Email, PatientValidationMessages.EmailCannotBeNullOrEmpty);
            Assertion.AssertStringIsNotNullOrEmpty(base.CPF.ToString(), PatientValidationMessages.CPFCannotBeNullOrEmpty);

            //Max lenght 150
            Assertion.AssertMaxValue(base.Name.Length, 150, PatientValidationMessages.NameGreaterThanLimit(150));
        }

    }
}
