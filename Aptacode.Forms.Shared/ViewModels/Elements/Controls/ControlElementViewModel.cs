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

                if(_controlModel != null)
                {
                    Name = _controlModel.Name;
                    Alignment = _controlModel.Alignment;
                    Label = new ElementLabelViewModel(_controlModel.Label);
                }
                else
                {
                    Name = string.Empty;
                    Alignment = ControlElement.VerticalAlignment.Center;
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
                if (ElementModel != null)
                {
                    ControlModel.Label = _label.Model;
                }
            }
        }

        private ControlElement.VerticalAlignment _alignment;

        public ControlElement.VerticalAlignment Alignment
        {
            get => _alignment;
            set
            {
                SetProperty(ref _alignment, value);
                if (ElementModel != null)
                {
                    ControlModel.Alignment = _alignment;
                }
            }
        }

        #endregion
    }
}