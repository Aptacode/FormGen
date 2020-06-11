﻿using Aptacode.Forms.Shared.ViewModels.Interfaces;

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

        public override ValidationResult Validate(ICheckBoxFieldViewModel input)
        {
            var passed = input.IsChecked == RequiredValue;
            var message = passed ? string.Empty : $"'{input.Label}' must be {RequiredValueString}";
            return new ValidationResult(this, passed, message);
        }

        #region Properties

        public bool RequiredValue { get; internal set; }
        private string RequiredValueString => RequiredValue ? "checked" : "unchecked";

        #endregion

    }
}