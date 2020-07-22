using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications
{
    public sealed class TypeNameEventSpecification : Specification<FormElementEvent>
    {
        internal TypeNameEventSpecification() { }

        public TypeNameEventSpecification(string eventType)
        {
            EventType = eventType;
        }
        public TypeNameEventSpecification(Type eventType)
        {
            EventType = eventType.Name;
        }

        public string EventType { get; set; }

        public override Expression<Func<FormElementEvent, bool>> ToExpression() =>
            formEvent => formEvent.GetType().Name == EventType;
    }
}