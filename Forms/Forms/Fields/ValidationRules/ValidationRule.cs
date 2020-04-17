using Aptacode.Forms.Forms.Fields.Inputs;

namespace Aptacode.Forms.Forms.Fields.ValidationRules
{
    public abstract class ValidationRule
    {
        protected ValidationRule()
        {
            
        }

        protected ValidationRule(string type)
        {
            Type = type;
        }
        public string Type { get; set; }
    }

    public abstract class ValidationRule<TInput> : ValidationRule where TInput : FieldInput
    {
        protected ValidationRule()
        {

        }

        protected ValidationRule(string type) : base(type)
        {

        }
    }
}