using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications {
    public sealed class PropertyValueEventSpecification : Specification<FormElementEvent>
    {
        public PropertyValueEventSpecification(string propertyName, object propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }

        public override Expression<Func<FormElementEvent, bool>> ToExpression() =>
            formEvent => formEvent.GetType().GetProperty(PropertyName).GetValue(formEvent) == PropertyValue;
    }
}