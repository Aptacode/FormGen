using System;
using System.Collections.Generic;

namespace Aptacode.Forms.Shared.EventListeners.Events
{
    public class ValidationChangedEvent : FormFieldEvent
    {
        public ValidationChangedEvent(DateTime time, string elementName, IEnumerable<string> results) :
            base(time, elementName)
        {
            Results = results;
        }

        public IEnumerable<string> Results { get; set; }

        public override string ToString() =>
            $"Validation Result Changed: {string.Join("\n", Results)}";
    }
}