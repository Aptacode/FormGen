using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.Interfaces.Controls
{
    public interface INullElementViewModel : IControlElementViewModel
    {
        new NullElement Model { get; }
    }
}