using System.Linq;

namespace Aptacode.Forms.Elements.Fields.ValidationRules
{
    public class ComboBoxSelectionRequiredValidationRule : ValidationRule<ComboBoxField>
    {
        public ComboBoxSelectionRequiredValidationRule() : base(
            nameof(ComboBoxSelectionRequiredValidationRule))
        {
        }

        public override bool Passed(ComboBoxField field)
        {
            return field.Items.Contains(field.SelectedItem);
        }

        public override string GetMessage(ComboBoxField fieldInput)
        {
            return Passed(fieldInput) ? string.Empty : $"'{fieldInput.Label}' must select an option";
        }
    }
}