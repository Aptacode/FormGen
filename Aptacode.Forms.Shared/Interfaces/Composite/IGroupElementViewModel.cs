using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.Interfaces.Composite
{
    public interface IGroupElementViewModel : ICompositeElementViewModel
    {
        string Title { get; set; }
        new GroupElement Model { get; }
    }
}