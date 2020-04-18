using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Events
{
    public abstract class CheckBoxFieldEventArgs : FieldEventArgs
    {
        protected CheckBoxFieldEventArgs(CheckBoxField field) : base(field)
        {
            CheckBoxField = field;
        }

        public CheckBoxField CheckBoxField { get; set; }
    }

    public class CheckBoxFieldChangedEventArgs : CheckBoxFieldEventArgs
    {
        public CheckBoxFieldChangedEventArgs(CheckBoxField field, bool newValue) : base(field)
        {
            NewValue = newValue;
        }

        public bool NewValue { get; set; }
    }
}