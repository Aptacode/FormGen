using System.Collections.ObjectModel;
using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class ComboBoxFieldViewModel : FormFieldViewModel
    {
        private string _selectedContent;
        public ComboBoxField ComboBoxField;

        public ComboBoxFieldViewModel(ComboBoxField comboBoxField) : base(comboBoxField)
        {
            ComboBoxField = comboBoxField;
            SelectedContent = ComboBoxField.DefaultSelectedItem;
            Items = new ObservableCollection<string>(comboBoxField.Items);
        }

        public ObservableCollection<string> Items { get; set; }

        public string SelectedContent
        {
            get => _selectedContent;
            set
            {
                SetProperty(ref _selectedContent, value);
                UpdateValidationMessage();
            }
        }
    }
}