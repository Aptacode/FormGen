using Aptacode.Forms.Shared.Interfaces.Composite;
using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Composite
{
    public class NullCompositeViewModel : CompositeElementViewModel<NullCompositeElement>, INullCompositeViewModel
    {
        public NullCompositeViewModel() : base(new NullCompositeElement())
        {
        }

        NullCompositeElement INullCompositeViewModel.Model => base.Model;
    }
}