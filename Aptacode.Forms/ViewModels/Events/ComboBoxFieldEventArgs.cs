using System;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class ComboBoxFieldEventArgs : FormFieldEventArgs
    {
        protected ComboBoxFieldEventArgs(DateTime time) : base(time) { }
    }

    public class ComboBoxFieldChangedEventArgs : ComboBoxFieldEventArgs
    {
        public ComboBoxFieldChangedEventArgs(DateTime time, string newValue) : base(time)
        {
            NewValue = newValue;
        }

        public string NewValue { get; set; }

        public override string ToString() => $"ComboBox Selection Changed: {NewValue}";
    }
}