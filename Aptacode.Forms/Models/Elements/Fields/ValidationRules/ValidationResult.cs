namespace Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules {
    public class ValidationResult
    {
        public ValidationResult() { }

        public ValidationResult(ValidationRule rule, bool passed, string message)
        {
            Rule = rule;
            Passed = passed;
            Message = message;
        }

        public ValidationRule Rule { get; internal set; }
        public string Message { get; internal set; }
        public bool Passed { get; internal set; }
    }
}