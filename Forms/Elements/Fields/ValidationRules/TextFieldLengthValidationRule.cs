namespace Aptacode.Forms.Elements.Fields.ValidationRules
{
    public class TextFieldLengthValidationRule : ValidationRule<TextField>
    {
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

            //True if the EqualityOperator is not included OR the comparison passes
            var greaterThanCheck = !greaterThan || contentLength > Value;
            var equalToCheck = !equalTo || contentLength == Value;
            var lessThanCheck = !lessThan || contentLength < Value;

            //True if all checks pass
            return greaterThanCheck && equalToCheck && lessThanCheck;
        }

        public override string GetMessage(TextField fieldInput)
        {
            return Passed(fieldInput) ? string.Empty : $"'{fieldInput.Label}' must be {EqualityOperatorToString()} {Value}";
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