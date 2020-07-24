using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class UniformRowElementViewModel : CompositeElementViewModel
    {
        private UniformRowElement _model;

        public UniformRowElementViewModel(UniformRowElement model) : base(model)
        {
            Model = model;
        }

        public new UniformRowElement Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }
    }
}