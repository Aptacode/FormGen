using Aptacode.Forms.Shared.Elements.Fields;

namespace Aptacode.Forms.Shared.Events
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