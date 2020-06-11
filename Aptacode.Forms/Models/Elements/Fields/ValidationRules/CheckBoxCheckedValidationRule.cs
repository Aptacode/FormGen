using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules
{
    public class CheckBoxCheckedValidationRule : ValidationRule<ICheckBoxFieldViewModel>
    {
        internal CheckBoxCheckedValidationRule() : base(
            nameof(CheckBoxCheckedValidationRule)) { }

        public CheckBoxCheckedValidationRule(bool requiredValue) : base(
            nameof(CheckBoxCheckedValidationRule))
        {
            RequiredValue = requiredValue;
        }

        public override bool Passed(ICheckBoxFieldViewModel fieldViewModel) =>
            fieldViewModel.IsChecked == RequiredValue;

        public override string GetMessage(ICheckBoxFieldViewModel fieldViewModelInput) => Passed(fieldViewModelInput)
            ? string.Empty
            : $"'{fieldViewModelInput.Label}' must be {RequiredValueString}";

        #region Properties

        public bool RequiredValue { get; internal set; }
        private string RequiredValueString => RequiredValue ? "checked" : "unchecked";

        #endregion
    }
}