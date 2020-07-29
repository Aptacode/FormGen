using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Aptacode.Forms.Wpf.Views.Elements.Composite.LayoutStrategy {
    public class StretchLayoutStrategy : LayoutStrategy
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

            var remainingWidth = finalSize.Width - children.Sum(c => c.DesiredSize.Width);

            remainingWidth = remainingWidth > 0 ? remainingWidth : 0;
            var additionalWidth = remainingWidth / children.Count();
            double xOffset = 0;
            foreach (var child in children)
            {
                var width = child.DesiredSize.Width + additionalWidth;
                child.Arrange(new Rect(xOffset, 0, width, finalSize.Height));
                xOffset += width;
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

            var remainingHeight = finalSize.Height - children.Sum(c => c.DesiredSize.Height);
            remainingHeight = remainingHeight > 0 ? remainingHeight : 0;
            var additionalHeight = remainingHeight / children.Count();

            double yOffset = 0;
            foreach (var child in children)
            {
                var height = child.DesiredSize.Height + additionalHeight;
                child.Arrange(new Rect(0, yOffset, finalSize.Width, height));
                yOffset += height;
            }

            return finalSize;
        }
    }
}