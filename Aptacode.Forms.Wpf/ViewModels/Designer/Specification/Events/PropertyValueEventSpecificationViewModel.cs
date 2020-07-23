using System.Linq;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification.Events
{
    public class ElementPropertyFormSpecificationViewModel : SpecificationViewModel<FormViewModel>
    {
        public ElementPropertyFormSpecificationViewModel() : base(nameof(ElementPropertyFormSpecification)) { }

        public override Specification<FormViewModel> BuildSpecification()
        {
            var parameters = Parameters?.Split(',');
            var parameter1 = parameters?.ElementAt(0);
            var parameter2 = parameters?.ElementAt(1);
            var parameter3 = parameters?.ElementAt(2);
            return new ElementPropertyFormSpecification(parameter1, parameter2, parameter3);
        }

        public override void LoadParameters(Specification<FormViewModel> specification)
        {
            if (specification is ElementPropertyFormSpecification spec)
            {
                Parameters = $"{spec?.ElementName},{spec?.PropertyName},{spec?.PropertyValue}";
            }
        }
    }
}