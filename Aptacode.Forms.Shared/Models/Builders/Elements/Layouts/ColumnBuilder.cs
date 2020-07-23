using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public class ColumnBuilder : LayoutBuilder<ColumnElement, ColumnBuilder>
    {

        public override ColumnElement Build()
        {
            var newElement = new ColumnElement
            {
                Id = Id,
                Name = Name,
                Children = Children,
                HorizontalAlignment = HorizontalAlignment,
                VerticalAlignment = VerticalAlignment,
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}