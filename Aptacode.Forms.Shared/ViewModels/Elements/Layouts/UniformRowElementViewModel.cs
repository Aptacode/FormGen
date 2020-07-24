using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class UniformRowElementViewModel : CompositeElementViewModel<UniformRowElement>, IUniformRowElementViewModel
    {
        public UniformRowElementViewModel(UniformRowElement model) : base(model) { }

        UniformRowElement IUniformRowElementViewModel.Model => base.Model;
    }
}