using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public sealed class NullElementViewModel : ControlElementViewModel<NullElement>, INullElementViewModel
    {
        public NullElementViewModel() : base(new NullElement()) { }
        public new ElementLabelViewModel Label { get; set; } = new ElementLabelViewModel(ElementLabel.None);
        NullElement INullElementViewModel.Model => base.Model;
    }
}