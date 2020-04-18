using Aptacode.Forms.Enums;

namespace Aptacode.Forms.Elements
{
    public class ButtonElement : FormElement
    {
        public ButtonElement()
        {
        }

        public ButtonElement(string name, string content, LabelPosition labelPosition, string label) : base(
            nameof(ButtonElement), name, labelPosition, label)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}