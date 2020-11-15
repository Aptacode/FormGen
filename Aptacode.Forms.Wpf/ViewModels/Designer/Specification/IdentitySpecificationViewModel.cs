using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Expressions.Bool;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification
{
    public class IdentitySpecificationViewModel<T> : SpecificationViewModel<T>
    {
        public IdentitySpecificationViewModel() : base(nameof(IdentitySpecification<T>)) { }

        public override void LoadParameters(IBooleanExpression<T> specification)
        {
            Parameters = "";
        }

        public override IBooleanExpression<T> BuildSpecification() => new ConstantBool<T>(true);
    }
}