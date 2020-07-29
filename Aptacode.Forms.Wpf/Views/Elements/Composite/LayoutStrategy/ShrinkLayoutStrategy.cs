using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Aptacode.Forms.Wpf.Views.Elements.Composite.LayoutStrategy {
    public class ShrinkLayoutStrategy : LayoutStrategy
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
                child.Arrange(new Rect(xOffset, 0, child.DesiredSize.Width, finalSize.Height));
                xOffset += child.DesiredSize.Width;
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
                child.Arrange(new Rect(0, yOffset, finalSize.Width, child.DesiredSize.Height));
                yOffset += child.DesiredSize.Height;
            }

            return finalSize;
        }
    }
}