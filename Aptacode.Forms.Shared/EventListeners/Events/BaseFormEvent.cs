using System;

namespace Aptacode.Forms.Shared.EventListeners.Events
{
    public abstract class FormElementEvent : EventArgs
    {
        protected FormElementEvent(DateTime time, string elementName)
        {
            Time = time;
            ElementName = elementName;
        }

        public string ElementName { get; set; }
        public DateTime Time { get; internal set; }
        public abstract override string ToString();
    }

    public abstract class FormFieldEvent : FormElementEvent
    {
        protected FormFieldEvent(DateTime time, string elementName) : base(time,
            elementName) { }
    }
}