using System.Linq;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public abstract class FluentValidator<TField> : IValidationRule<TField> where TField : IFieldViewModel
    {
        [JsonIgnore] protected Validator validator = new Validator();

        protected FluentValidator(string message)
        {
            Message = message;
        }


        public ValidationResult Validate(TField instance)
        {
            var fluentResult = validator.Validate(instance);
            return new ValidationResult(fluentResult.IsValid, fluentResult.Errors.Select(error => error.ErrorMessage));
        }

        public string Message { get; set; }

        protected class Validator : AbstractValidator<TField> { }
    }
}