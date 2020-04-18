using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aptacode.Forms.Elements.Fields.Results
{
    public class FormResult
    {
        public FormResult(Form form, IEnumerable<FieldResult> fieldResults)
        {
            Form = form;
            FieldResults = fieldResults;
            FormName = form.Name;
        }

        [JsonIgnore]
        public Form Form { get; set; }

        public string FormName { get; set; }

        public IEnumerable<FieldResult> FieldResults { get; set; }
    }
}