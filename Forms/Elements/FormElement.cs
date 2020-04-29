using System;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;

namespace Aptacode.Forms.Elements
{
    public abstract class FormElement : IEquatable<FormElement>
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

        #region Equality

        public override int GetHashCode()
        {
            return (Name, Label, Type).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is FormElement other && Equals(other);
        }

        public bool Equals(FormElement other)
        {
            return other != null && Type.Equals(other.Type) && Name.Equals(other.Name) && Label.Equals(other.Label);
        }

        #endregion Equality
    }
}