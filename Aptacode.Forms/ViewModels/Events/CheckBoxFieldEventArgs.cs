using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class CheckBoxFieldEventArgs : FieldEventArgs
    {
        protected CheckBoxFieldEventArgs(ICheckBoxFieldViewModel sender, CheckBoxFieldModel field) : base(sender, field)
        {
            CheckBoxField = field;
        }

        public CheckBoxFieldModel CheckBoxField { get; set; }
    }

    public class CheckBoxFieldChangedEventArgs : CheckBoxFieldEventArgs
    {
        public CheckBoxFieldChangedEventArgs(ICheckBoxFieldViewModel sender, CheckBoxFieldModel field, bool newValue) :
            base(sender,
                field)
        {
            NewValue = newValue;
        }

        public bool NewValue { get; set; }
    }
}