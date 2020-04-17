using System.Collections.Generic;

namespace Aptacode.Forms.Results
{
    public class FormResult
    {
        public FormResult(Form form, IEnumerable<FieldResult> fieldResults)
        {
            Form = form;
            FieldResults = fieldResults;
        }

        public Form Form { get; set; }

        public IEnumerable<FieldResult> FieldResults { get; set; }
    }
}