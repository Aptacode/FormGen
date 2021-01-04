using System.Linq;
using Aptacode.Expressions;
using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification.Conditions
{
    public class PropertyValueEventSpecificationViewModel : SpecificationViewModel<FormElementEvent>
    {
        public PropertyValueEventSpecificationViewModel() : base(nameof(PropertyValueEventSpecification)) { }

        public override IExpression<bool,FormElementEvent> BuildSpecification()
        {
            var parameters = Parameters?.Split(',');
            var parameter1 = parameters?.ElementAt(0);
            var parameter2 = parameters?.ElementAt(1);
            return new PropertyValueEventSpecification(parameter1, parameter2);
        }

        public override void LoadParameters(IExpression<bool,FormElementEvent> specification)
        {
            if (specification is PropertyValueEventSpecification spec)
            {
                Parameters = $"{spec?.PropertyName},{spec?.PropertyValue}";
            }
        }
    }
}