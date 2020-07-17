namespace Aptacode.Forms.Shared.Results
{
    public class CheckElementResult : FieldElementResult
    {
        internal CheckElementResult() { }

        public CheckElementResult(string elementName, bool isChecked) : base(elementName)
        {
            IsChecked = isChecked;
        }

        public bool IsChecked { get; set; }
    }
}