using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public class GroupBuilder : LayoutBuilder<GroupElement, GroupBuilder>
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
                Children = Children,
                Title = Title
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