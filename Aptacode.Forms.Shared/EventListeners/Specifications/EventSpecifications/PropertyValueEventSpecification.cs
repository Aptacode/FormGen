using Aptacode.Forms.Shared.EventListeners.Events;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications
{
    public class PropertyValueEventSpecification : PropertyValueSpecification<FormElementEvent>
    {
        public PropertyValueEventSpecification(string propertyName, object propertyValue) : base(propertyName,
            propertyValue)
        {
        }
    }
}