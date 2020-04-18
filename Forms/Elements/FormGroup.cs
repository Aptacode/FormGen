using System.Collections.Generic;

namespace Aptacode.Forms.Elements
{
    public class FormGroup
    {
        public FormGroup()
        {
        }

        public FormGroup(string label, IEnumerable<FormRow> rows)
        {
            Label = label;
            Rows = rows;
        }

        public string Label { get; set; }
        public IEnumerable<FormRow> Rows { get; set; }
    }
}