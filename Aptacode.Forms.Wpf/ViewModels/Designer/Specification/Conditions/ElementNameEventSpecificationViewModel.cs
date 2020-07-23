using System.Linq;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification.Conditions
{
    public class ElementNameEventSpecificationViewModel : SpecificationViewModel<FormElementEvent>
    {
        public ElementNameEventSpecificationViewModel() : base(nameof(ElementNameEventSpecification)) { }

        public override Specification<FormElementEvent> BuildSpecification()
        {
            var parameters = Parameters?.Split(',');
            var parameter1 = parameters?.ElementAt(0);
            return new ElementNameEventSpecification(parameter1);
        }

        public override void LoadParameters(Specification<FormElementEvent> specification)
        {
            if (specification is ElementNameEventSpecification spec)
            {
                Parameters = spec?.ElementName;
            }
        }
    }
}