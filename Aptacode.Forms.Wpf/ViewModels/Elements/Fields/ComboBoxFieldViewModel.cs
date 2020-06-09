using System.Collections.ObjectModel;
using Aptacode.Forms.Shared.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Elements.Fields
{
    public class ComboBoxFieldViewModel : FormFieldViewModel
    {
        public ComboBoxFieldViewModel(ComboBoxField comboBoxField) : base(comboBoxField)
        {
            ComboBoxField = comboBoxField;
            SelectedItem = ComboBoxField.DefaultSelectedItem;
            DefaultSelectedItem = ComboBoxField.DefaultSelectedItem;
            Items = new ObservableCollection<string>(comboBoxField.Items);
        }

        #region Properties

        public ComboBoxField ComboBoxField { get; set; }

        public ObservableCollection<string> Items { get; set; }
        private string _defaultSelectedItem;

        public string DefaultSelectedItem
        {
            get => _defaultSelectedItem;
            set
            {
                SetProperty(ref _defaultSelectedItem, value);
                ComboBoxField.DefaultSelectedItem = _defaultSelectedItem;
                SelectedItem = _defaultSelectedItem;
            }
        }

        private string _selectedItem;

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

        #endregion
    }
}