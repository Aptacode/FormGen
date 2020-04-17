namespace Aptacode.Forms.Elements.Fields.Results
{
    public abstract class FieldResult
    {
        protected FieldResult(FormField formField)
        {
            FormField = formField;
        }

        public FormField FormField { get; set; }
    }
}