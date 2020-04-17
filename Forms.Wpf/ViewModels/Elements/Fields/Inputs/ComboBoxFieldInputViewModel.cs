using Aptacode.Forms.Fields.Inputs;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields.Inputs
{
    public class ComboBoxFieldInputViewModel : FormFieldInputViewModel
    {
        private string _content;
        public ComboBoxField ComboBoxField;

        public ComboBoxFieldInputViewModel(ComboBoxField comboBoxField) : base(comboBoxField)
        {
            ComboBoxField = comboBoxField;
        }

        public string Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                UpdateMessage();
            }
        }
    }
}