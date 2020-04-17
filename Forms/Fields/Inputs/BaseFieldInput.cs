using System.Collections.Generic;
using System.Text;
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

        public abstract string GetValidationMessage();
    }
}