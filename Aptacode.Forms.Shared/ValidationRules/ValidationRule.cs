using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public interface IValidationRule
    {
        string Message { get; set; }
    }

    public interface IValidationRule<TField> : IValidationRule where TField : IFieldViewModel
    {
        ValidationResult Validate(TField instance);
    }
}