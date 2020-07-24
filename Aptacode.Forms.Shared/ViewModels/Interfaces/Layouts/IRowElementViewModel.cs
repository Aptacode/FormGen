using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts
{
    public interface IRowElementViewModel : ICompositeElementViewModel
    {
        new RowElement Model { get; }
    }
}