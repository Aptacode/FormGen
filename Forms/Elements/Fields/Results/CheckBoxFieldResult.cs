namespace Aptacode.Forms.Elements.Fields.Results
{
    public class CheckBoxFieldResult : FieldResult
    {
        public CheckBoxFieldResult(CheckBoxField checkBoxField, bool isChecked) : base(checkBoxField)
        {
            IsChecked = isChecked;
        }

        public bool IsChecked { get; set; }
    }
}