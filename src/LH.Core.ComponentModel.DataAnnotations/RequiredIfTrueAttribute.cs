using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace LH.Core.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredIfTrueAttribute : BaseValidationAttribute, IClientModelValidator
    {
        private string PropertyName { get; set; }

        public RequiredIfTrueAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();

            bool.TryParse(type.GetProperty(PropertyName).GetValue(instance)?.ToString(), out bool propertyValue);

            if (propertyValue && string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            string errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-requirediftrue", errorMessage);
            MergeAttribute(context.Attributes, "data-val-requirediftrue-property", PropertyName);
        }
    }
}
