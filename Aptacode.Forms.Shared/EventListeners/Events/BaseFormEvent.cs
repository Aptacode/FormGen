using System;
using System.Collections.Generic;

namespace Aptacode.Forms.Shared.EventListeners.Events
{
    public abstract class FormElementEvent : EventArgs
    {
        protected FormElementEvent(string eventType, DateTime time, string elementName)
        {
            Time = time;
            ElementName = elementName;
            EventType = eventType;
        }

        public string ElementName { get; set; }
        public string EventType { get; set; }

        public DateTime Time { get; internal set; }
        public abstract override string ToString();
    }

    public abstract class FormFieldEvent : FormElementEvent
    {
        protected FormFieldEvent(string eventType, DateTime time, string elementName) : base(eventType, time, elementName) { }
    }

    public class ValidationChangedEvent : FormFieldEvent
    {
        public ValidationChangedEvent(DateTime time, string elementName, IEnumerable<string> results) :
            base(nameof(ValidationChangedEvent), time, elementName)
        {
            Results = results;
        }

        public IEnumerable<string> Results { get; set; }

        public override string ToString() =>
            $"Validation Result Changed: {string.Join("\n", Results)}";
    }
}