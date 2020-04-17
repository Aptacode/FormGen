namespace Aptacode.Forms.Elements
{
    public class FormRow
    {
        public FormRow()
        {
        }

        public FormRow(FormElement element)
        {
            Element = element;
        }

        public FormElement Element { get; set; }
    }
}