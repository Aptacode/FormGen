using Aptacode.Forms.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public abstract class FormFieldViewModel : FormElementViewModel
    {
        private string _label;

        private FieldLabelPosition _labelPosition;

        protected FormFieldViewModel(FormField field) : base(field)
        {
            Field = field;
            Label = field.Label;
            LabelPosition = field.LabelPosition;
        }

        public FormField Field { get; }

        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public FieldLabelPosition LabelPosition
        {
            get => _labelPosition;
            set => SetProperty(ref _labelPosition, value);
        }

        private string _validationMessage;

        public string ValidationMessage
        {
            get => _validationMessage;
            set => SetProperty(ref _validationMessage, value);
        }

        public void UpdateMessage()
        {
            ValidationMessage = Field.GetValidationMessage();
        }
    }
}