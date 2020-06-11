using System;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class TextFieldEventArgs : FormFieldEventArgs
    {
        protected TextFieldEventArgs(DateTime time) : base(time) { }
    }

    public class TextFieldChangedEventArgs : TextFieldEventArgs
    {
        public TextFieldChangedEventArgs(DateTime time, string oldContent,
            string newContent) :
            base(time)
        {
            OldContent = oldContent;
            NewContent = newContent;
        }

        public string OldContent { get; set; }
        public string NewContent { get; set; }

        public override string ToString() => $"TextField Changed: {OldContent} => {NewContent}";
    }
}