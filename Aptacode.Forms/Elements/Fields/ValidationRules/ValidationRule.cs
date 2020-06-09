namespace Aptacode.Forms.Shared.Elements.Fields.ValidationRules
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

    public abstract class ValidationRule<TField> : ValidationRule where TField : FormField
    {
        protected ValidationRule()
        {
        }

        protected ValidationRule(string type) : base(type)
        {
        }

        public abstract bool Passed(TField fieldInput);

        public abstract string GetMessage(TField fieldInput);
    }
}