using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.EventListeners.Events;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications
{
    public sealed class ElementNameEventSpecification : NaryBoolExpression<FormElementEvent>
    {
        public ElementNameEventSpecification(string elementName)
        {
            ElementName = elementName;
        }

        public string ElementName { get; set; }

        public override bool Interpret(FormElementEvent context)
        {
            return context.ElementName == ElementName;
        }
    }
}