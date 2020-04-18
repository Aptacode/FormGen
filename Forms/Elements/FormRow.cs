using System.Collections.Generic;

namespace Aptacode.Forms.Elements
{
    public class FormRow
    {
        public FormRow()
        {
        }

        public FormRow(int span, IEnumerable<FormColumn> columns)
        {
            Span = span;
            Columns = columns;
        }

        public IEnumerable<FormColumn> Columns { get; set; }
        public int Span { get; set; }
    }
}