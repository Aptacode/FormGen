using System.Collections.Generic;
using Aptacode.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Fields.Inputs
{
    public abstract class BaseFieldInput
    {
        protected BaseFieldInput()
        {
        }

        protected BaseFieldInput(string type, IEnumerable<ValidationRule> rules)
        {
            Type = type;
            ValidationRules = rules;
        }

        public string Type { get; set; }
        public IEnumerable<ValidationRule> ValidationRules { get; set; }

        public abstract bool IsValid();

        public abstract IEnumerable<string> GetValidationMessages();

        public string GetValidationMessage()
        {
            return string.Join("\n", GetValidationMessages());
        }
    }
}