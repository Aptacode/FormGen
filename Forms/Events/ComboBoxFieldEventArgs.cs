using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Events
{
    public abstract class ComboBoxFieldEventArgs : FieldEventArgs
    {
        protected ComboBoxFieldEventArgs(ComboBoxField field) : base(field)
        {
            ComboBoxField = field;
        }

        public ComboBoxField ComboBoxField { get; set; }
    }

    public class ComboBoxFieldChangedEventArgs : ComboBoxFieldEventArgs
    {
        public ComboBoxFieldChangedEventArgs(ComboBoxField field, string newValue) : base(field)
        {
            NewValue = newValue;
        }

        public string NewValue { get; set; }
    }
}