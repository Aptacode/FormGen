using Aptacode.Forms.Fields.Inputs;

namespace Aptacode.Forms.Fields.ValidationRules
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
        public string PassMessage { get; set; }
        public string FailMessage { get; set; }
    }

    public abstract class ValidationRule<TInput> : ValidationRule where TInput : BaseFieldInput
    {
        protected ValidationRule()
        {
        }

        protected ValidationRule(string type) : base(type)
        {
        }

        public abstract bool Passed(TInput fieldInput);

        public string GetMessage(TInput fieldInput)
        {
            return Passed(fieldInput) ? PassMessage : FailMessage;
        }
    }
}