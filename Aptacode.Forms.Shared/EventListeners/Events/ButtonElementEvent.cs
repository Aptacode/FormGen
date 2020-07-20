using System;

namespace Aptacode.Forms.Shared.EventListeners.Events
{
    public abstract class ButtonElementEvent : FormElementEvent
    {
        protected ButtonElementEvent(DateTime time, string elementName) : base(time, elementName) { }
    }

    public class ButtonElementClickedEvent : ButtonElementEvent
    {
        public ButtonElementClickedEvent(DateTime time, string elementName) : base(time, elementName) { }

        public override string ToString() => "Button Clicked";
    }
}