using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.Interfaces.Composite
{
    public interface INullCompositeViewModel : ICompositeElementViewModel
    {
        new NullCompositeElement Model { get; }
    }
}