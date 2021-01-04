using Aptacode.Forms.Shared.Interfaces.Composite;
using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Composite
{
    public sealed class LinearLayoutElementViewModel : CompositeElementViewModel<LinearLayoutElement>,
        ILinearLayoutElementViewModel
    {
        public LinearLayoutElementViewModel(LinearLayoutElement model) : base(model)
        {
        }
    }
}