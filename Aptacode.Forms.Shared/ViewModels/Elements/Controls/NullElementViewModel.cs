using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public sealed class NullElementViewModel : ControlElementViewModel<NullElement>, INullElementViewModel
    {
        public NullElementViewModel() : base(new NullElement())
        {
        }

        public new ElementLabelViewModel Label { get; set; } = new(ElementLabel.None);
        NullElement INullElementViewModel.Model => base.Model;
    }
}