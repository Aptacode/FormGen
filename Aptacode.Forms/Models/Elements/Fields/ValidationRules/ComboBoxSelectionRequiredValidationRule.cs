using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules
{
    public class ComboBoxSelectionRequiredValidationRule : ValidationRule<IComboBoxFieldViewModel>
    {
        public ComboBoxSelectionRequiredValidationRule() : base(
            nameof(ComboBoxSelectionRequiredValidationRule)) { }

        public override bool Passed(IComboBoxFieldViewModel field) => field.Items.Contains(field.SelectedItem);

        public override string GetMessage(IComboBoxFieldViewModel fieldInput) =>
            Passed(fieldInput) ? string.Empty : $"'{fieldInput.Label}' must select an option";
    }
}