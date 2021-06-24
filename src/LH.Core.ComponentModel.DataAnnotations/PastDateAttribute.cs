using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace LH.Core.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PastDateAttribute : BaseValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime now = DateTime.Now;

            if (((DateTime)value) > now)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            string errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-pastdate", errorMessage);
        }
    }
}
