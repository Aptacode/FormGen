using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class ComboBoxFieldEventArgs : FieldEventArgs
    {
        protected ComboBoxFieldEventArgs(IComboBoxFieldViewModel sender, ComboBoxFieldModel model) : base(sender, model)
        {
            ComboBoxField = model;
            Sender = sender;
        }

        public IComboBoxFieldViewModel Sender { get; set; }

        public ComboBoxFieldModel ComboBoxField { get; set; }
    }

    public class ComboBoxFieldChangedEventArgs : ComboBoxFieldEventArgs
    {
        public ComboBoxFieldChangedEventArgs(IComboBoxFieldViewModel field, ComboBoxFieldModel model, string newValue) :
            base(field,
                model)
        {
            NewValue = newValue;
        }

        public string NewValue { get; set; }
    }
}