using System;

namespace Aptacode.Forms.Shared.EventListeners.Events
{
    public abstract class TextElementEvent : FormFieldEvent
    {
        protected TextElementEvent(DateTime time, string elementName) : base(time,
            elementName) { }
    }

    public class TextElementChangedEvent : TextElementEvent
    {
        public TextElementChangedEvent(DateTime time, string elementName, string oldContent,
            string newContent) :
            base(time, elementName)
        {
            OldContent = oldContent;
            NewContent = newContent;
        }

        public string OldContent { get; set; }
        public string NewContent { get; set; }

        public override string ToString() => $"TextField Changed: {OldContent} => {NewContent}";
    }
}