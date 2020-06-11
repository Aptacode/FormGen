using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using System;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class ComboBoxFieldEventArgs : FieldEventArgs
    {
        protected ComboBoxFieldEventArgs(DateTime time, IComboBoxFieldViewModel sender, ComboBoxFieldModel model) : base(time, sender, model)
        {
            ComboBoxField = model;
            Sender = sender;
        }

        public IComboBoxFieldViewModel Sender { get; set; }

        public ComboBoxFieldModel ComboBoxField { get; set; }
    }

    public class ComboBoxFieldChangedEventArgs : ComboBoxFieldEventArgs
    {
        public ComboBoxFieldChangedEventArgs(DateTime time, IComboBoxFieldViewModel field, ComboBoxFieldModel model, string newValue) :
            base(time, field,
                model)
        {
            NewValue = newValue;
        }

        public string NewValue { get; set; }

        public override string ToString() => $"ComboBox Selection Changed: {ComboBoxField.Name} = {NewValue}";

    }
}