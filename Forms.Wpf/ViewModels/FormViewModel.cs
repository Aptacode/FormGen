using System.Collections.ObjectModel;
using Aptacode.Forms.Fields;
using Aptacode.Forms.Fields.Inputs;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class TextFieldInputViewModel : FormFieldInputViewModel
    {
        public TextBaseField TextField;
        public TextFieldInputViewModel(TextBaseField textBaseField) : base(textBaseField)
        {
            TextField = textBaseField;
        }


        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                TextField.Content = _content;
                UpdateMessage();
            }
        }
    }

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

    public class FormFieldViewModel : FormElementViewModel
    {
        public FormField Field { get; }

        public FormFieldViewModel(FormField field) : base(field)
        {
            Field = field;
        }
    }

    public class FormElementViewModel : BindableBase
    {
        public FormElement Element { get; }

        public FormElementViewModel(FormElement element)
        {
            Element = element;
        }
    }

    public abstract class FormRowViewModel : BindableBase
    {
        public FormRow Row { get; }

        public FormRowViewModel(FormRow row)
        {
            Row = row;
        }
    }

    public class FormViewModel : BindableBase
    {
        public Form Form { get; }

        public FormViewModel(Form form)
        {
            Form = form;
        }

        public ObservableCollection<FormRowViewModel> Rows { get; set; }

    }
}
