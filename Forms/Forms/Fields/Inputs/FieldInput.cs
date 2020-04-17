using System.Collections.Generic;
using Aptacode.Forms.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Forms.Fields.Inputs
{
    public abstract class FieldInput
    {
        protected FieldInput()
        {

        }

        protected FieldInput(string type, IEnumerable<ValidationRule> rules)
        {
            Type = type;
            ValidationRules = rules;
        }
        public string Type { get; set; }
        public IEnumerable<ValidationRule> ValidationRules { get; set; }
    }
}