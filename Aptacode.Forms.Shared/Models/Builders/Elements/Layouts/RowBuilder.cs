using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public class RowBuilder : LayoutBuilder<RowElement, RowBuilder>
    {
        private int Span { get; set; } = 1;

        public RowBuilder SetSpan(int span)
        {
            Span = span;
            return this;
        }

        public override RowElement Build()
        {
            var newElement = new RowElement
            {
                Id = Id,
                Name = Name,
                Children = Children,
                Span = Span
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            Span = 1;
            base.Reset();
        }
    }
}