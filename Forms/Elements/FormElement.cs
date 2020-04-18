using System;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;

namespace Aptacode.Forms.Elements
{
    public abstract class FormElement
    {
        protected FormElement()
        {
        }

        protected FormElement(string type, string name, LabelPosition labelPosition, string label)
        {
            Name = name;
            Type = type;
            LabelPosition = labelPosition;
            Label = label;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public LabelPosition LabelPosition { get; set; }

        #region Events

        public event EventHandler<FormElementEvent> OnFormEvent;

        protected void TriggerEvent(FormElementEvent eventArgs)
        {
            OnFormEvent?.Invoke(this, eventArgs);
        }

        #endregion
    }
}