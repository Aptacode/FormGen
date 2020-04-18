using Aptacode.Forms.Enums;

namespace Aptacode.Forms.Elements
{
    public class HtmlElement : FormElement
    {
        public HtmlElement()
        {
        }

        public HtmlElement(string name, string content, LabelPosition labelPosition, string label) : base(
            nameof(HtmlElement), name, labelPosition, label)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}