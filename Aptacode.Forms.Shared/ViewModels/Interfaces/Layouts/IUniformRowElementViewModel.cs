using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts
{
    public interface IUniformRowElementViewModel : ICompositeElementViewModel
    {
        new UniformRowElement Model { get; }
    }
}