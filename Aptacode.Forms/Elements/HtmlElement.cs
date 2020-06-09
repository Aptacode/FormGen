using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Shared.Elements
{
    public class HtmlElement : FormElement
    {
        internal HtmlElement()
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