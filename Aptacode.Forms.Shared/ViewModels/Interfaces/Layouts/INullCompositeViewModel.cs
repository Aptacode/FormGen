using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts
{
    public interface INullCompositeViewModel : ICompositeElementViewModel
    {
        new NullCompositeElement Model { get; }
    }
}