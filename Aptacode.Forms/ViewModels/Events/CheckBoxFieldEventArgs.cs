using System;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class CheckBoxFieldEventArgs : FieldEventArgs
    {
        protected CheckBoxFieldEventArgs(DateTime time, ICheckBoxFieldViewModel sender, CheckBoxFieldModel field) :
            base(time, sender, field)
        {
            CheckBoxField = field;
        }

        public CheckBoxFieldModel CheckBoxField { get; set; }
    }

    public class CheckBoxFieldChangedEventArgs : CheckBoxFieldEventArgs
    {
        public CheckBoxFieldChangedEventArgs(DateTime time, ICheckBoxFieldViewModel sender, CheckBoxFieldModel field,
            bool newValue) :
            base(time, sender,
                field)
        {
            NewValue = newValue;
        }

        public bool NewValue { get; set; }

        public override string ToString() => $"Checkbox Check Changed: {CheckBoxField.Name}";
    }
}