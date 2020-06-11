namespace Aptacode.Forms.Shared.Models.Elements
{
    public class HtmlElementModel : FormElementModel
    {
        internal HtmlElementModel() { }

        public HtmlElementModel(string name, ElementLabel label, string content) : base(
            nameof(HtmlElementModel), name, label)
        {
            Content = content;
        }

        public string Content { get; internal set; }
    }
}