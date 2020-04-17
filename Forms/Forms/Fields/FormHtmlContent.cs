namespace Aptacode.Forms.Forms.Fields
{
    public class FormHtmlContent: FormRow
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