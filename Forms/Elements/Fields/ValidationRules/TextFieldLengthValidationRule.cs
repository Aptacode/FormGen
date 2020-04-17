namespace Aptacode.Forms.Elements.Fields.ValidationRules
{
    public class TextFieldLengthValidationRule : ValidationRule<TextField>
    {
        public TextFieldLengthValidationRule(EqualityOperator equalityOperator, int value) : base(
            nameof(TextFieldLengthValidationRule))
        {
            EqualityOperator = equalityOperator;
            Value = value;

            FailMessage = $"Must be ~ {value}";
        }

        public EqualityOperator EqualityOperator { get; set; }
        public int Value { get; set; }

        public override bool Passed(TextField field)
        {
            var contentLength = field.Content.Length;

            //True if the EqualityOperator is not included OR the comparison passes
            var greaterThanCheck = (EqualityOperator & EqualityOperator.GreaterThan) == EqualityOperator.None ||
                                   Value > contentLength;
            var equalToCheck = (EqualityOperator & EqualityOperator.EqualTo) == EqualityOperator.None ||
                               Value == contentLength;
            var lessThanCheck = (EqualityOperator & EqualityOperator.LessThan) == EqualityOperator.None ||
                                Value < contentLength;

            //True if all checks pass
            return greaterThanCheck && equalToCheck && lessThanCheck;
        }
    }
}