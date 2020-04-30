using Aptacode.Forms.Elements;
using Aptacode.Forms.Enums;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Elements
{
    public abstract class FormElementViewModel : BindableBase
    {
        private LabelPosition _labelPosition;

        protected FormElementViewModel(FormElement formElement)
        {
            FormElement = formElement;
            Name = formElement.Name;
            Label = formElement.Label;
            LabelPosition = formElement.LabelPosition;
        }

        #region Properties

        public FormElement FormElement { get; }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                FormElement.Name = _name;
            } 
        }

        private string _label;

        public string Label
        {
            get => _label;
            set
            {
                SetProperty(ref _label, value);
                FormElement.Label = _label;
            }
        }

        public LabelPosition LabelPosition
        {
            get => _labelPosition;
            set
            {
                SetProperty(ref _labelPosition, value);
                FormElement.LabelPosition = _labelPosition;
            }
        }

        #endregion
    }
}