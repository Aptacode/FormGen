namespace Aptacode.Forms.Shared.ValidationRules
{
    public struct ValidationResult
    {
        public ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
        public ValidationResult(bool isValid)
        {
            IsValid = isValid;
            Message = string.Empty;
        }

        #region Properties

        public bool IsValid { get; }
        public string Message { get; private set; }

        public bool HasMessage => !string.IsNullOrEmpty(Message);
        #endregion

        public static ValidationResult Success(string message = "")
        {
            return new ValidationResult(true, message);
        }

        public static ValidationResult Fail(string message = "")
        {
            return new ValidationResult(false, message);
        }

        public ValidationResult WithMessage(string message)
        {
            return new ValidationResult(this.IsValid, message);
        }


        #region Equals

        public override bool Equals(object obj)
        {
            if (!(obj is ValidationResult other))
            {
                return false;
            }

            return IsValid == other.IsValid && Message == other.Message;
        }

        public override int GetHashCode()
        {
            return (IsValid, Message).GetHashCode();
        }

        #endregion
    }
}