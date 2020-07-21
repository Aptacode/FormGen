using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public sealed class NullElementViewModel : FormElementViewModel
    {
        public NullElementViewModel() : base(new NullElement()) { }
    }
}