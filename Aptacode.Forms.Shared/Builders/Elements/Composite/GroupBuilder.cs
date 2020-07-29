using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.Builders.Elements.Composite
{
    public class GroupBuilder : CompositeBuilder<GroupElement, GroupBuilder>
    {
        private string Title { get; set; } = string.Empty;

        public GroupBuilder SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public override GroupElement Build()
        {
            var newElement = new GroupElement
            {
                Id = Id,
                Name = Name,
                HorizontalAlignment = HorizontalAlignment,
                VerticalAlignment = VerticalAlignment,
                Children = Children,
                Title = Title,
                LayoutMode = LayoutMode,
                LayoutOrientation = LayoutOrientation
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            Title = string.Empty;
            base.Reset();
        }
    }
}