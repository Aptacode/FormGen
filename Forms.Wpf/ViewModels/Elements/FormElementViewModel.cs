using Aptacode.Forms.Elements;
using Aptacode.Forms.Enums;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Elements
{
    public abstract class FormElementViewModel : BindableBase
    {
        protected FormElementViewModel(FormElement formElement)
        {
            FormElement = formElement;
            Label = formElement.Label;
            LabelPosition = formElement.LabelPosition;
        }

        public FormElement FormElement { get; }
        private string _label;

        private LabelPosition _labelPosition;
        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public LabelPosition LabelPosition
        {
            get => _labelPosition;
            set => SetProperty(ref _labelPosition, value);
        }
    }
}