using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Aptacode.Forms.Wpf.Views.Elements.Composite.LayoutStrategy {
    public class UniformLayoutStrategy : LayoutStrategy
    {
        public override Size ArrangeHorizontal(Size finalSize, IReadOnlyList<UIElement> children)
        {
            if (!children.Any())
            {
                return finalSize;
            }

            foreach (var child in children)
            {
                child.Measure(finalSize);
            }

            var maxWidth = children.Select(c => c.DesiredSize.Width).Max();
            var remainingWidth = finalSize.Width - maxWidth * children.Count();
            if (remainingWidth >= 0)
            {
                maxWidth += remainingWidth / children.Count();
            }

            double xOffset = 0;
            foreach (var child in children)
            {
                child.Arrange(new Rect(xOffset, 0, maxWidth, finalSize.Height));
                xOffset += maxWidth;
            }

            return finalSize;
        }

        public override Size ArrangeVertical(Size finalSize, IReadOnlyList<UIElement> children)
        {
            if (!children.Any())
            {
                return finalSize;
            }

            foreach (var child in children)
            {
                child.Measure(finalSize);
            }

            var maxHeight = children.Select(c => c.DesiredSize.Height).Max();
            var remainingHeight = finalSize.Height - maxHeight * children.Count();
            if (remainingHeight >= 0)
            {
                maxHeight += remainingHeight / children.Count();
            }

            double yOffset = 0;
            foreach (var child in children)
            {
                child.Arrange(new Rect(0, yOffset, finalSize.Width, maxHeight));
                yOffset += maxHeight;
            }

            return finalSize;
        }
    }
}