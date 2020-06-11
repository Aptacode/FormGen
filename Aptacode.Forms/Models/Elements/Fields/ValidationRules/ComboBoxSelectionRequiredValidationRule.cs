using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules
{
    public class ComboBoxSelectionRequiredValidationRule : ValidationRule<IComboBoxFieldViewModel>
    {
        public ComboBoxSelectionRequiredValidationRule() : base(
            nameof(ComboBoxSelectionRequiredValidationRule)) { }

        public override ValidationResult Validate(IComboBoxFieldViewModel input)
        {
            var passed = input.Items.Contains(input.SelectedItem);
            var message = passed ? string.Empty : $"'{input.Label}' must select an option";
            return new ValidationResult(this, passed, message);
        }
    }
}