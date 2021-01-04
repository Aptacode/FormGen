using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Expressions;
using Aptacode.Expressions.Bool;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification
{
    public class IdentitySpecificationViewModel<T> : SpecificationViewModel<T>
    {
        public IdentitySpecificationViewModel() : base(nameof(IdentitySpecification<T>)) { }

        public override void LoadParameters(IExpression<bool, T> specification)
        {
            Parameters = "";
        }

        public override IExpression<bool, T> BuildSpecification() => new ConstantBool<T>(true);
    }
}