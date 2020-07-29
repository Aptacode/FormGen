using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.Builders.Elements.Controls
{
    public class HtmlElementBuilder : ControlBuilder<HtmlElement, HtmlElementBuilder>
    {
        private string Content { get; set; } = string.Empty;

        public HtmlElementBuilder SetContent(string content)
        {
            Content = content;
            return this;
        }

        public override HtmlElement Build()
        {
            var newElement = new HtmlElement
            {
                Id = Id,
                Name = Name,
                Label = Label,
                HorizontalAlignment = HorizontalAlignment,
                VerticalAlignment = VerticalAlignment,
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