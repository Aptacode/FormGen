using Aptacode.Forms.Elements;

namespace Aptacode.Forms.Layout
{
    public class FormColumn
    {
        internal FormColumn()
        {
        }

        public FormColumn(int span, FormElement element)
        {
            Element = element;
            Span = span;
        }

        public FormElement Element { get; set; }
        public int Span { get; set; }
    }
}