using System;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules
{
    public class ValidationResult : IEquatable<ValidationResult>
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

        #region Equality

        public bool Equals(ValidationResult other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Rule, other.Rule) && Message == other.Message && Passed == other.Passed;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((ValidationResult) obj);
        }

        public override int GetHashCode() => (Rule, Message, Passed).GetHashCode();

        #endregion
    }
}