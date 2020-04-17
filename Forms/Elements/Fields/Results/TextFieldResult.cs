namespace Aptacode.Forms.Elements.Fields.Results
{
    public class TextFieldResult : FieldResult
    {
        public TextFieldResult(TextField textField, string content) : base(textField)
        {
            content = Content;
        }

        public string Content { get; set; }
    }
}