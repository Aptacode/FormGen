namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    public class HtmlElement : ControlElement
    {
        internal HtmlElement() { }

        public HtmlElement(string name, ElementLabel label, string content) : base(
            nameof(HtmlElement), name, label)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}