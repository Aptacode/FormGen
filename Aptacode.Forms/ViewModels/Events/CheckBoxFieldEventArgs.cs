using System;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class CheckBoxFieldEventArgs : FormFieldEventArgs
    {
        protected CheckBoxFieldEventArgs(DateTime time) : base(time) { }
    }

    public class CheckBoxFieldChangedEventArgs : CheckBoxFieldEventArgs
    {
        public CheckBoxFieldChangedEventArgs(DateTime time, bool newValue) :
            base(time)
        {
            NewValue = newValue;
        }

        public bool NewValue { get; set; }

        public override string ToString() => $"CheckBox Checked: {NewValue}";
    }
}