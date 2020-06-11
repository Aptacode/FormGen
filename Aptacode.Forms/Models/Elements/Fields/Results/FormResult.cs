using System.Collections.Generic;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.Results
{
    public class FormResult
    {
        internal FormResult() { }

        public FormResult(FormModel form, IEnumerable<FieldResult> fieldResults)
        {
            Form = form;
            FieldResults = fieldResults;
        }

        public FormModel Form { get; internal set; }

        public IEnumerable<FieldResult> FieldResults { get; internal set; }
    }
}