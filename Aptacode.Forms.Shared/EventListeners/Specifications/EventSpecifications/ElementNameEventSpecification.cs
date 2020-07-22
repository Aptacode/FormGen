using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications {
    public sealed class ElementNameEventSpecification : Specification<FormElementEvent>
    {
        internal ElementNameEventSpecification() { }
        public ElementNameEventSpecification(string elementName)
        {
            ElementName = elementName;
        }

        public string ElementName { get; set; }

        public override Expression<Func<FormElementEvent, bool>> ToExpression() =>
            formEvent => formEvent.ElementName == ElementName;
    }
}