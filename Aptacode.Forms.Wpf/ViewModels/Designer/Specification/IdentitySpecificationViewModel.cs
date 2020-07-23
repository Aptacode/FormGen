using Aptacode.CSharp.Common.Patterns.Specification;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification
{
    public class IdentitySpecificationViewModel<T> : SpecificationViewModel<T>
    {
        public IdentitySpecificationViewModel() : base(nameof(IdentitySpecification<T>)) { }

        public override void LoadParameters(Specification<T> specification)
        {
            Parameters = "";
        }

        public override Specification<T> BuildSpecification() => new IdentitySpecification<T>();
    }
}