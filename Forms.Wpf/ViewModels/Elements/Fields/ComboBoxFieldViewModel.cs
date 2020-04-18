using System.Collections.ObjectModel;
using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class ComboBoxFieldViewModel : FormFieldViewModel
    {
        private string _selectedItem;
        public ComboBoxField ComboBoxField;

        public ComboBoxFieldViewModel(ComboBoxField comboBoxField) : base(comboBoxField)
        {
            ComboBoxField = comboBoxField;
            SelectedItem = ComboBoxField.DefaultSelectedItem;
            Items = new ObservableCollection<string>(comboBoxField.Items);
        }

        public ObservableCollection<string> Items { get; set; }

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                ComboBoxField.SelectedItem = _selectedItem;
                UpdateValidationMessage();
            }
        }
    }
}