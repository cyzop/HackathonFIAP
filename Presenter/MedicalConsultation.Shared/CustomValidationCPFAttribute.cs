﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MedicalConsultation.Shared
{
    public class CustomValidationCPFAttribute : ValidationAttribute, IClientValidatable
    {
        public CustomValidationCPFAttribute() { }

        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            bool valido = Util.ValidaCPF(value.ToString());
            return valido;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = this.FormatErrorMessage(null),
                ValidationType = "customvalidationcpf"
            };
        }
    }
}
