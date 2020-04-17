using Aptacode.Forms.Enums;

namespace Aptacode.Forms.Elements
{
    public class FormHtmlContent : FormElement
    {
        public FormHtmlContent()
        {
        }

        public FormHtmlContent(string name, string content, LabelPosition labelPosition, string label) : base(nameof(FormHtmlContent), name, labelPosition, label)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}