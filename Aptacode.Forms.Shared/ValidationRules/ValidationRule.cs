using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public interface IValidationRule
    {
        string Type { get; set; }
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }

    public interface IValidationRule<TField> : IValidationRule where TField : IFieldViewModel
    {
        ValidationResult Validate(TField instance);
    }

    public abstract class FluentValidator<TField> : IValidationRule<TField> where TField : IFieldViewModel
    {
        [JsonIgnore] protected Validator validator = new Validator();

        protected FluentValidator() { }

        protected FluentValidator(string type)
        {
            Type = type;
        }

        public string Type { get; set; }

        public ValidationResult Validate(TField instance)
        {
            var fluentResult = validator.Validate(instance);
            return new ValidationResult
            {
                IsValid = fluentResult.IsValid,
                ErrorMessages = fluentResult.Errors.Select(error => error.ErrorMessage)
            };
        }

        protected class Validator : AbstractValidator<TField> { }
    }
}