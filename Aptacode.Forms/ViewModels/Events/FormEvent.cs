using System;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class FormEventArgs : EventArgs
    {
        protected FormEventArgs(DateTime time)
        {
            Time = time;
        }

        public DateTime Time { get; internal set; }
        public abstract override string ToString();
    }

    public abstract class FormElementEvent : FormEventArgs
    {
        protected FormElementEvent(DateTime time) : base(time) { }
    }

    public abstract class FieldEventArgs : FormElementEvent
    {
        protected FieldEventArgs(DateTime time, IFieldViewModel sender, FormFieldModel field) : base(time)
        {
            Field = field;
            Sender = sender;
        }

        public IFieldViewModel Sender { get; set; }
        public FormFieldModel Field { get; set; }
    }
}