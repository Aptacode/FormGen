using System;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class FormEventArgs : EventArgs { }

    public abstract class FormElementEvent : FormEventArgs { }

    public abstract class FieldEventArgs : FormElementEvent
    {
        protected FieldEventArgs(IFieldViewModel sender, FormFieldModel field)
        {
            Field = field;
            Sender = sender;
        }

        public IFieldViewModel Sender { get; set; }
        public FormFieldModel Field { get; set; }
    }
}