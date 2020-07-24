using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Controls
{
    public interface INullElementViewModel : IControlElementViewModel
    {
        new NullElement Model { get; }
    }
}