using System.Collections.Generic;

namespace Aptacode.Forms.Elements.Fields.Results
{
    public class ComboBoxFieldResult : FieldResult
    {
        public ComboBoxFieldResult(ComboBoxField comboBoxField, bool isChecked) : base(comboBoxField)
        {
            IsChecked = isChecked;
        }

        public bool IsChecked { get; set; }
    }
}