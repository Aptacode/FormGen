using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class NullCompositeViewModel : CompositeElementViewModel<NullCompositeElement>, INullCompositeViewModel
    {
        public NullCompositeViewModel() : base(new NullCompositeElement()) { }

        NullCompositeElement INullCompositeViewModel.Model => base.Model;
    }
}