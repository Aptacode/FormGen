using Aptacode.Forms.Shared.Models.Enums;

namespace Aptacode.Forms.Shared.Models.Elements
{
    public class HtmlElementModel : FormElementModel
    {
        internal HtmlElementModel() { }

        public HtmlElementModel(string name, string content, LabelPosition labelPosition, string label) : base(
            nameof(HtmlElementModel), name, labelPosition, label)
        {
            Content = content;
        }

        public string Content { get; internal set; }
    }
}