namespace Aptacode.Forms.Shared.Results
{
    public class TextElementResult : FieldElementResult
    {
        internal TextElementResult()
        {
        }

        public TextElementResult(string elementName, string content) : base(elementName)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}