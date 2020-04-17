using Aptacode.Forms.Fields.Inputs;

namespace Aptacode.Forms.Results
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