namespace Aptacode.Forms.Shared.Results
{
    public class SelectElementResult : FieldElementResult
    {
        internal SelectElementResult() { }

        public SelectElementResult(string elementName, string selectedItem) : base(elementName)
        {
            SelectedItem = selectedItem;
        }

        public string SelectedItem { get; set; }
    }
}