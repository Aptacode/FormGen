using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public class RowBuilder : LayoutBuilder<RowElement, RowBuilder>
    {
        public override RowElement Build()
        {
            var newElement = new RowElement
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