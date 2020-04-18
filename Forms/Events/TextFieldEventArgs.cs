using Aptacode.Forms.Elements.Fields;

namespace Aptacode.Forms.Events
{
    public abstract class TextFieldEventArgs : FieldEventArgs
    {
        protected TextFieldEventArgs(TextField field) : base(field)
        {
            TextField = field;
        }

        public TextField TextField { get; set; }
    }

    public class TextFieldChangedEventArgs : TextFieldEventArgs
    {
        public TextFieldChangedEventArgs(TextField field, string oldContent, string newContent) : base(field)
        {
            OldContent = oldContent;
            NewContent = newContent;
        }

        public string OldContent { get; set; }
        public string NewContent { get; set; }
    }
}