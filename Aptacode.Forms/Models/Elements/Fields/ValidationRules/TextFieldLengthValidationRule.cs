using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules
{
    public class TextFieldLengthValidationRule : ValidationRule<ITextFieldViewModel>
    {
        internal TextFieldLengthValidationRule() : base(
            nameof(TextFieldLengthValidationRule)) { }

        public TextFieldLengthValidationRule(EqualityOperator equalityOperator, int value) : base(
            nameof(TextFieldLengthValidationRule))
        {
            EqualityOperator = equalityOperator;
            Value = value;
        }

        public EqualityOperator EqualityOperator { get; internal set; }
        public int Value { get; internal set; }

        public override ValidationResult Validate(ITextFieldViewModel input)
        {
            var passed = Passed(input);
            var message = passed ? string.Empty : $"'{input.Name}' must be {EqualityOperatorToString()} {Value}";
            return new ValidationResult(this, passed, message);
        }
        private bool Passed(ITextFieldViewModel field)
        {
            var contentLength = field.Content.Length;

            var greaterThan = (EqualityOperator & EqualityOperator.GreaterThan) != EqualityOperator.None;
            var equalTo = (EqualityOperator & EqualityOperator.EqualTo) != EqualityOperator.None;
            var lessThan = (EqualityOperator & EqualityOperator.LessThan) != EqualityOperator.None;

            var greaterThanCheck = contentLength > Value;
            var equalToCheck = contentLength == Value;
            var lessThanCheck = contentLength < Value;

            if (equalTo && equalToCheck)
            {
                return true;
            }

            if (greaterThan && greaterThanCheck)
            {
                return true;
            }

            return lessThan && lessThanCheck;
        }

        private string EqualityOperatorToString()
        {
            var greaterThan = (EqualityOperator & EqualityOperator.GreaterThan) != EqualityOperator.None;
            var equalTo = (EqualityOperator & EqualityOperator.EqualTo) != EqualityOperator.None;
            var lessThan = (EqualityOperator & EqualityOperator.LessThan) != EqualityOperator.None;

            if (greaterThan && !equalTo && !lessThan)
            {
                return "greater than";
            }

            if (greaterThan && equalTo && !lessThan)
            {
                return "greater than or equal to";
            }

            if (!greaterThan && equalTo && !lessThan)
            {
                return "equal to";
            }

            if (!greaterThan && !equalTo && !lessThan)
            {
                return "not equal to";
            }

            if (greaterThan && !equalTo && lessThan)
            {
                return "not equal to";
            }

            if (!greaterThan && equalTo && lessThan)
            {
                return "less than or equal to";
            }

            if (!greaterThan && !equalTo && lessThan)
            {
                return "less than";
            }

            //Todo - error here cannot be not == && > && <
            if (greaterThan && equalTo && lessThan)
            {
                return "not equal to";
            }

            return string.Empty;
        }
    }
}