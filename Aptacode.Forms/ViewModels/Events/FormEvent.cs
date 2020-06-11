using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;

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

    public abstract class FormElementEventArgs : FormEventArgs
    {
        protected FormElementEventArgs(DateTime time) : base(time) { }
    }

    public abstract class FormFieldEventArgs : FormElementEventArgs
    {
        protected FormFieldEventArgs(DateTime time) : base(time) { }
    }

    public class ValidationChangedEventArgs : FormFieldEventArgs
    {
        public ValidationChangedEventArgs(DateTime time, IEnumerable<ValidationResult> results) :
            base(time)
        {
            Results = results;
        }

        public IEnumerable<ValidationResult> Results { get; set; }

        public override string ToString() =>
            $"Validation Result Changed: {string.Join("\n", Results.Select(r => r.Message))}";
    }
}