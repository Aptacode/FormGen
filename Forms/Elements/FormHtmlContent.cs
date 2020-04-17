namespace Aptacode.Forms.Elements
{
    public class FormHtmlContent : FormElement
    {
        public FormHtmlContent()
        {
        }

        public FormHtmlContent(string name, string content) : base(nameof(FormHtmlContent), name)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}