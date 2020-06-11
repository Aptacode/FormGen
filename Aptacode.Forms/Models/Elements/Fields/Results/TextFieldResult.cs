using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.Results
{
    public class TextFieldResult : FieldResult
    {
        internal TextFieldResult() { }

        public TextFieldResult(ITextFieldViewModel viewModel, TextFieldModel model) : base(model)
        {
            Content = viewModel.Content;
        }

        public new TextFieldModel Model { get; internal set; }
        public string Content { get; internal set; }
    }
}