using Aptacode.Forms.Fields.Inputs;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormFieldInputViewModel : BindableBase
    {
        public BaseFieldInput BaseFieldInput { get; set; }
        public FormFieldInputViewModel(BaseFieldInput baseFieldInput)
        {
            BaseFieldInput = baseFieldInput;
        }

        private string _validationMessage;
        public string ValidationMessage
        {
            get => _validationMessage;
            set => SetProperty(ref _validationMessage, value);
        }

        public void UpdateMessage()
        {
            ValidationMessage = BaseFieldInput.GetValidationMessage();
        }
    }
}