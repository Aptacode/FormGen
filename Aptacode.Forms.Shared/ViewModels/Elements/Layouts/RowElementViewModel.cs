using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class RowElementViewModel : CompositeElementViewModel<RowElement>, IRowElementViewModel
    {
        public RowElementViewModel(RowElement model) : base(model) { }

        RowElement IRowElementViewModel.Model => base.Model;
    }
}