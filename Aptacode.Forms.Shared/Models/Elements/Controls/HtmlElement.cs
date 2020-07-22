namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    public class HtmlElement : ControlElement
    {
        internal HtmlElement() { }

        public HtmlElement(string name, ElementLabel label, VerticalAlignment alignment, string content) : base(
            name, label, alignment)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}