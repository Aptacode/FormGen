using System;
using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.EventListeners.Events;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications
{
    public sealed class TypeNameEventSpecification : NaryBoolExpression<FormElementEvent>
    {
        internal TypeNameEventSpecification()
        {
        }

        public TypeNameEventSpecification(string eventType)
        {
            EventType = eventType;
        }

        public TypeNameEventSpecification(Type eventType)
        {
            EventType = eventType.Name;
        }

        public string EventType { get; set; }

        public override bool Interpret(FormElementEvent context)
        {
            return context.GetType().Name == EventType;
        }
    }
}