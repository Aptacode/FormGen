using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public abstract class ControlElementViewModel<TElement> : FormElementViewModel<TElement>, IControlElementViewModel
        where TElement : ControlElement, new()
    {
        protected ControlElementViewModel(TElement model) : base(model)
        {
            Label = new ElementLabelViewModel(model.Label);
        }

        #region Properties

        ControlElement IControlElementViewModel.Model => base.Model;


        private ElementLabelViewModel _label;

        public ElementLabelViewModel Label
        {
            get => _label;
            set
            {
                SetProperty(ref _label, value);
                Model.Label = _label.Model;
            }
        }

        #endregion
    }
}