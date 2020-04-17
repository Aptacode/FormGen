using Aptacode.Forms.Fields;
using Aptacode.Forms.Wpf.ViewModels.Elements.Fields.Inputs;
using Aptacode.Forms.Wpf.ViewModels.Factories;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class FormFieldViewModel : FormElementViewModel
    {
        private FormFieldInputViewModel _formFieldInputViewModel;

        private string _label;

        private FieldLabelPosition _labelPosition;

        public FormFieldViewModel(FormField field) : base(field)
        {
            Field = field;
            Label = field.Label;
            LabelPosition = field.LabelPosition;

            FormFieldInputViewModel = FormFieldInputFactory.Create(field.Input);
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

        public FormFieldInputViewModel FormFieldInputViewModel
        {
            get => _formFieldInputViewModel;
            set => SetProperty(ref _formFieldInputViewModel, value);
        }
    }
}