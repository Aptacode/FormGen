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

                if (_controlModel != null)
                {
                    Name = _controlModel.Name;

                    if (_controlModel.Label == null)
                    {
                        _controlModel.Label = ElementLabel.None;
                    }

                    Label = new ElementLabelViewModel(_controlModel.Label);
                }
                else
                {
                    Name = string.Empty;
                    Label = new ElementLabelViewModel(ElementLabel.None);
                }
            }
        }

        private ElementLabelViewModel _label;

        public ElementLabelViewModel Label
        {
            get => _label;
            set
            {
                SetProperty(ref _label, value);

                if (_controlModel != null && _label != null)
                {
                    _controlModel.Label = _label.Model;
                }
            }
        }

        #endregion
    }
}