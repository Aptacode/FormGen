using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public abstract class ControlElementViewModel : FormElementViewModel
    {
        protected ControlElementViewModel(ControlElement elementModel) : base(elementModel)
        {
            ControlModel = elementModel;
        }

        #region Properties

        private ControlElement _controlModel;

        public ControlElement ControlModel
        {
            get => _controlModel;
            set
            {
                SetProperty(ref _controlModel, value);

                Name = _controlModel?.Name;
                Label = _controlModel?.Label ?? default;
            }
        }

        private ElementLabel _label;

        public ElementLabel Label
        {
            get => _label;
            set
            {
                SetProperty(ref _label, value);
                if (ElementModel != null)
                {
                    ControlModel.Label = _label;
                }
            }
        }

        #endregion
    }
}