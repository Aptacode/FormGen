namespace Aptacode.Forms.Elements
{
    public class FormColumn
    {
        public FormColumn()
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