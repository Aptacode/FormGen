namespace Aptacode.Forms.Elements
{
    public abstract class FormRow
    {
        protected FormRow()
        {
        }

        protected FormRow(FormElement element)
        {
            Element = element;
        }

        public FormElement Element { get; set; }
    }
}