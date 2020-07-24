using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public class UniformRowBuilder : LayoutBuilder<UniformRowElement, UniformRowBuilder>
    {
        public override UniformRowElement Build()
        {
            var newElement = new UniformRowElement
            {
                Id = Id,
                Name = Name,
                Children = Children,
                HorizontalAlignment = HorizontalAlignment,
                VerticalAlignment = VerticalAlignment
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