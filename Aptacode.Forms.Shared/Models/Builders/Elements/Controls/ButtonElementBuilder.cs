using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Controls
{
    public class ButtonElementBuilder : ControlBuilder<ButtonElement, ButtonElementBuilder>
    {
        private string Content { get; set; } = string.Empty;

        public ButtonElementBuilder SetContent(string content)
        {
            Content = content;
            return this;
        }

        public override ButtonElement Build()
        {
            var newElement = new ButtonElement
            {
                Id = Id,
                Name = Name,
                Label = Label,
                Alignment = Alignment,
                Content = Content
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            Content = string.Empty;
            base.Reset();
        }
    }
}