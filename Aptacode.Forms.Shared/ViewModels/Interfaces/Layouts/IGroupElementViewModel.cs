using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts
{
    public interface IGroupElementViewModel : ICompositeElementViewModel
    {
        string Title { get; set; }
        new GroupElement Model { get; }
    }
}