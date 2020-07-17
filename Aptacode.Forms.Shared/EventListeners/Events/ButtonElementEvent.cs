using System;

namespace Aptacode.Forms.Shared.EventListeners.Events
{
    public abstract class ButtonElementEvent : FormElementEvent
    {
        protected ButtonElementEvent(string eventType, DateTime time, string elementName) : base(eventType, time, elementName) { }
    }

    public class ButtonElementClickedEvent : ButtonElementEvent
    {
        public ButtonElementClickedEvent(DateTime time, string elementName) : base(nameof(ButtonElementClickedEvent), time, elementName) { }

        public override string ToString() => "Button Clicked";
    }
}