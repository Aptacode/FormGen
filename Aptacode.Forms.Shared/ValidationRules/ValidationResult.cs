using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public struct ValidationResult
    {
        public ValidationResult(bool isValid, IEnumerable<string> messages)
        {
            IsValid = isValid;
            Messages = messages;
        }


        #region Properties

        public bool IsValid { get; }
        public IEnumerable<string> Messages { get; }

        #endregion

        #region Equals

        public override bool Equals(object obj)
        {
            if (!(obj is ValidationResult other))
            {
                return false;
            }

            return IsValid == other.IsValid && Messages.SequenceEqual(other.Messages);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = Messages.Aggregate(19, (current, message) => current * 31 + message.GetHashCode());
                hash = hash * 31 + IsValid.GetHashCode();
                return hash;
            }
        }

        #endregion
    }
}