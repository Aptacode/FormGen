using System;

namespace Aptacode.Forms.Shared.EventListeners.Events
{
    public abstract class CheckElementEvent : FormFieldEvent
    {
        protected CheckElementEvent(string eventType, DateTime time, string elementName) : base(eventType, time,
            elementName) { }
    }

    public class CheckElementChangedEvent : CheckElementEvent
    {
        public CheckElementChangedEvent(DateTime time, string elementName, bool newValue) :
            base(nameof(CheckElementChangedEvent), time, elementName)
        {
            NewValue = newValue;
        }

        public bool NewValue { get; set; }

        public override string ToString() => $"CheckBox Checked: {NewValue}";
    }
}