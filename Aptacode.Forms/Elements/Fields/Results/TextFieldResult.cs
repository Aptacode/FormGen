namespace Aptacode.Forms.Shared.Elements.Fields.Results
{
    public class TextFieldResult : FieldResult
    {
        public TextFieldResult(TextField textField, string content) : base(textField)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}