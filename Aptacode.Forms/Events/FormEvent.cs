using System;
using Aptacode.Forms.Shared.Elements.Fields;

namespace Aptacode.Forms.Shared.Events
{
    public abstract class FormEventArgs : EventArgs
    {
    }

    public abstract class FormElementEvent : FormEventArgs
    {
    }

    public abstract class FieldEventArgs : FormElementEvent
    {
        protected FieldEventArgs(FormField field)
        {
            Field = field;
        }

        public FormField Field { get; set; }
    }
}