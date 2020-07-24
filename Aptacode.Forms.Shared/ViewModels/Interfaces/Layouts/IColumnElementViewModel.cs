using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts
{
    public interface IColumnElementViewModel : ICompositeElementViewModel
    {
        new ColumnElement Model { get; }
    }
}