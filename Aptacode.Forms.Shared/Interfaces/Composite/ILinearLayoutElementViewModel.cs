using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.Interfaces.Composite
{
    public interface ILinearLayoutElementViewModel : ICompositeElementViewModel
    {
        new LinearLayoutElement Model { get; }
    }
}