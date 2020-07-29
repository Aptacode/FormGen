using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Aptacode.Forms.Wpf.Views.Elements.Composite {
    public class LastChildFillLayoutStrategy : LayoutStrategy
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

            double xOffset = 0;
            foreach (var child in children)
            {
                var width = child.DesiredSize.Width;

                if (child == children.Last())
                {
                    var remainingWidth = finalSize.Width - xOffset;
                    if (width < remainingWidth)
                    {
                        width = remainingWidth;
                    }
                }

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

            double yOffset = 0;
            foreach (var child in children)
            {
                var height = child.DesiredSize.Height;

                if (child == children.Last())
                {
                    var remainingHeight = finalSize.Height - yOffset;
                    if (height < remainingHeight)
                    {
                        height = remainingHeight;
                    }
                }

                child.Arrange(new Rect(0, yOffset, finalSize.Width, height));
                yOffset += height;
            }

            return finalSize;
        }
    }
}