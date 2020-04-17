namespace Aptacode.Forms.Elements.Fields.ValidationRules
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

    public abstract class ValidationRule<TField> : ValidationRule where TField : FormField
    {
        protected ValidationRule()
        {
        }

        protected ValidationRule(string type) : base(type)
        {
        }

        public abstract bool Passed(TField fieldInput);

        public string GetMessage(TField fieldInput)
        {
            return Passed(fieldInput) ? PassMessage : FailMessage;
        }
    }
}