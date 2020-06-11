namespace Aptacode.Forms.Shared.Models.Elements.Fields.Results
{
    public abstract class FieldResult
    {
        internal FieldResult() { }

        protected FieldResult(FormFieldModel model)
        {
            Model = model;
        }

        public FormFieldModel Model { get; internal set; }
    }
}