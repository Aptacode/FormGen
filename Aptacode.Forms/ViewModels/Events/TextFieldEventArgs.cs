using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using System;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class TextFieldEventArgs : FieldEventArgs
    {
        protected TextFieldEventArgs(DateTime time, ITextFieldViewModel sender, TextFieldModel model) : base(time, sender, model)
        {
            TextField = sender;
        }

        public ITextFieldViewModel TextField { get; set; }
    }

    public class TextFieldChangedEventArgs : TextFieldEventArgs
    {
        public TextFieldChangedEventArgs(DateTime time, ITextFieldViewModel field, TextFieldModel model, string oldContent,
            string newContent) :
            base(time, field, model)
        {
            OldContent = oldContent;
            NewContent = newContent;
        }

        public string OldContent { get; set; }
        public string NewContent { get; set; }

        public override string ToString() => $"TextField Changed: {TextField.Name} = {NewContent}";

    }
}