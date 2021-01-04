using System;

namespace Aptacode.Forms.Shared.EventListeners.Events
{
    public abstract class TextElementEvent : FormFieldEvent
    {
        protected TextElementEvent(DateTime time, string elementName) : base(time,
            elementName)
        {
        }
    }

    public class TextElementChangedEvent : TextElementEvent
    {
        public TextElementChangedEvent(DateTime time, string elementName, string oldValue,
            string newValue) :
            base(time, elementName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public override string ToString()
        {
            return $"TextField Changed: {OldValue} => {NewValue}";
        }
    }
}