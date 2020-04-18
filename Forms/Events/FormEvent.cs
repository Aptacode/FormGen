using System;
using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Events
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