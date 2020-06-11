using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class TextFieldEventArgs : FieldEventArgs
    {
        protected TextFieldEventArgs(ITextFieldViewModel sender, TextFieldModel model) : base(sender, model)
        {
            TextField = sender;
        }

        public ITextFieldViewModel TextField { get; set; }
    }

    public class TextFieldChangedEventArgs : TextFieldEventArgs
    {
        public TextFieldChangedEventArgs(ITextFieldViewModel field, TextFieldModel model, string oldContent,
            string newContent) :
            base(field, model)
        {
            OldContent = oldContent;
            NewContent = newContent;
        }

        public string OldContent { get; set; }
        public string NewContent { get; set; }
    }
}