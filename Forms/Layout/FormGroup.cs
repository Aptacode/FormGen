using System.Collections.Generic;

namespace Aptacode.Forms.Layout
{
    public class FormGroup
    {
        internal FormGroup()
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