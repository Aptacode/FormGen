namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    public class HtmlElement : ControlElement
    {
        public HtmlElement(string name, ElementLabel label, string content) : base(
            name, label)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}