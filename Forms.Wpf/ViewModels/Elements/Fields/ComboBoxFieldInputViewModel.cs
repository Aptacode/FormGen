using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class ComboBoxFieldViewModel : FormFieldViewModel
    {
        private string _content;
        public ComboBoxField ComboBoxField;

        public ComboBoxFieldViewModel(ComboBoxField comboBoxField) : base(comboBoxField)
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