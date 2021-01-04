using System;
using Aptacode.Expressions.Bool;

namespace Aptacode.Forms.Shared.EventListeners.Specifications
{
    public class PropertyValueSpecification<T> : NaryBoolExpression<T>
    {
        public PropertyValueSpecification(string propertyName, object propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }

        protected static object GetValue(object target, string propertyName) =>
            target?.GetType().GetProperty(propertyName)?.GetValue(target);

        protected static bool ValuesMatch(object left, object right)
        {
            return left == right || string.Equals(left.ToString(), right.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public override bool Interpret(T context)
        {
            return ValuesMatch(PropertyValue, GetValue(context, PropertyName));
        }
    }
}