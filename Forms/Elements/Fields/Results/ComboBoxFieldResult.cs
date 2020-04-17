using System.Collections.Generic;

namespace Aptacode.Forms.Elements.Fields.Results
{
    public class ComboBoxFieldResult : FieldResult
    {
        public ComboBoxFieldResult(ComboBoxField comboBoxField, IEnumerable<string> Items, string selectedItem) : base(comboBoxField)
        {
            SelectedItem = selectedItem;
        }

        public string SelectedItem { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}