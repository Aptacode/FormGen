namespace Aptacode.Forms.Elements.Fields.ValidationRules
{
    public class CheckBoxCheckedValidationRule : ValidationRule<CheckBoxField>
    {
        public CheckBoxCheckedValidationRule(bool requiredValue) : base(
            nameof(CheckBoxCheckedValidationRule))
        {
            RequiredValue = requiredValue;
        }

        public override bool Passed(CheckBoxField field)
        {
            return field.IsChecked == RequiredValue;
        }

        public override string GetMessage(CheckBoxField fieldInput)
        {
            return Passed(fieldInput) ? string.Empty : $"'{fieldInput.Label}' must be {RequiredValueString}";
        }

        #region Properties

        public bool RequiredValue { get; set; }
        private string RequiredValueString => RequiredValue ? "checked" : "unchecked";

        #endregion
    }
}