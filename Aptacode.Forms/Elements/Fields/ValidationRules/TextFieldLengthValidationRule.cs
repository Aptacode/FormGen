namespace Aptacode.Forms.Shared.Elements.Fields.ValidationRules
{
    public class TextFieldLengthValidationRule : ValidationRule<TextField>
    {
        internal TextFieldLengthValidationRule() : base(
            nameof(TextFieldLengthValidationRule))
        {
        }

        public TextFieldLengthValidationRule(EqualityOperator equalityOperator, int value) : base(
            nameof(TextFieldLengthValidationRule))
        {
            EqualityOperator = equalityOperator;
            Value = value;
        }

        public EqualityOperator EqualityOperator { get; set; }
        public int Value { get; set; }

        public override bool Passed(TextField field)
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

            if (lessThan && lessThanCheck)
            {
                return true;
            }

            return false;
        }

        public override string GetMessage(TextField fieldInput)
        {
            return Passed(fieldInput)
                ? string.Empty
                : $"'{fieldInput.Label}' must be {EqualityOperatorToString()} {Value}";
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