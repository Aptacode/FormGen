using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class ColumnElementViewModel : CompositeElementViewModel
    {
        private ColumnElement _model;

        public ColumnElementViewModel(ColumnElement model) : base(model)
        {
            Model = model;
        }

        public new ColumnElement Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }
    }
}