using System.Collections.Generic;

namespace Aptacode.Forms.Shared.Elements.Fields.Results
{
    public class ComboBoxFieldResult : FieldResult
    {
        public ComboBoxFieldResult(ComboBoxField comboBoxField, IEnumerable<string> items, string selectedItem) : base(
            comboBoxField)
        {
            Items = items;
            SelectedItem = selectedItem;
        }

        public IEnumerable<string> Items { get; set; }
        public string SelectedItem { get; set; }
    }
}