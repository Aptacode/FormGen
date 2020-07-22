using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications {

    public class PropertyValueEventSpecification : PropertyValueSpecification<FormElementEvent>
    {
        internal PropertyValueEventSpecification() { }

        public PropertyValueEventSpecification(string propertyName, object propertyValue) : base(propertyName, propertyValue)
        {

        }
    }

}