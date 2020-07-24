using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class UniformRowElementViewModel : CompositeElementViewModel
    {
        public UniformRowElementViewModel(UniformRowElement model) : base(model)
        {
            Model = model; }

        private UniformRowElement _model;
        public new UniformRowElement Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
            }
        }
    }
}