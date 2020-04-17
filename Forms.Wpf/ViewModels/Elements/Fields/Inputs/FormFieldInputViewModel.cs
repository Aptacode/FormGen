using Aptacode.Forms.Fields.Inputs;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields.Inputs
{
    public abstract class FormFieldInputViewModel : BindableBase
    {
        private string _validationMessage;

        protected FormFieldInputViewModel(BaseFieldInput fieldInput)
        {
            FieldInput = fieldInput;
        }

        public BaseFieldInput FieldInput { get; set; }

        public string ValidationMessage
        {
            get => _validationMessage;
            set => SetProperty(ref _validationMessage, value);
        }

        public void UpdateMessage()
        {
            ValidationMessage = FieldInput.GetValidationMessage();
        }
    }
}