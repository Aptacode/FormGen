using Newtonsoft.Json;

namespace Aptacode.Forms.Elements.Fields.Results
{
    public abstract class FieldResult
    {
        protected FieldResult(FormField formField)
        {
            FormField = formField;
            FieldName = FormField.Name;
        }

        public string FieldName { get; set; }

        [JsonIgnore]
        public FormField FormField { get; set; }
    }
}