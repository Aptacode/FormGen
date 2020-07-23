using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public class ColumnBuilder : LayoutBuilder<ColumnElement, ColumnBuilder>
    {
        private int Span { get; set; } = 1;

        public ColumnBuilder SetSpan(int span)
        {
            Span = span;
            return this;
        }

        public override ColumnElement Build()
        {
            var newElement = new ColumnElement
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