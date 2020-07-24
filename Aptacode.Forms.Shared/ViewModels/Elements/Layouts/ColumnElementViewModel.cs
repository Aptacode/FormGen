using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public sealed class ColumnElementViewModel : CompositeElementViewModel<ColumnElement>, IColumnElementViewModel
    {
        public ColumnElementViewModel(ColumnElement model) : base(model) { }
    }
}