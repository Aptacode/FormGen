using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Wpf.Views.Elements.Composite
{
    public abstract class LayoutStrategy
    {
        public abstract Size ArrangeHorizontal(Size finalSize, IReadOnlyList<UIElement> children);
        public abstract Size ArrangeVertical(Size finalSize, IReadOnlyList<UIElement> children);
    }

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

    public class LayoutPanel : StackPanel
    {
        public static readonly DependencyProperty layoutModeDependencyProperty =
            DependencyProperty.Register("LayoutMode", typeof(LayoutMode), typeof(LayoutPanel),
                new PropertyMetadata(LayoutMode.Stretch, LayoutModeChanged));

        public static readonly DependencyProperty layoutOrientationDependencyProperty =
            DependencyProperty.Register("LayoutOrientation", typeof(LayoutOrientation), typeof(LayoutPanel),
                new PropertyMetadata(LayoutOrientation.Vertical, LayoutOrientationChanged));

        public LayoutMode LayoutMode
        {
            get => (LayoutMode) GetValue(layoutModeDependencyProperty);
            set
            {
                switch (value)
                {
                    case LayoutMode.Uniform:
                        Layout = new UniformLayoutStrategy();
                        break;
                    case LayoutMode.Stretch:
                        Layout = new StretchLayoutStrategy();
                        break;
                    case LayoutMode.Shrink:
                        Layout = new ShrinkLayoutStrategy();
                        break;
                    case LayoutMode.LastChildFill:
                        Layout = new LastChildFillLayoutStrategy();
                        break;
                }

                SetValue(layoutModeDependencyProperty, value);
                InvalidateVisual();
            }
        }

        public LayoutOrientation LayoutOrientation
        {
            get => (LayoutOrientation) GetValue(layoutOrientationDependencyProperty);
            set
            {
                SetValue(layoutOrientationDependencyProperty, value);
                InvalidateVisual();
            }
        }

        public LayoutStrategy Layout { get; set; } = new StretchLayoutStrategy();

        private static void LayoutModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LayoutPanel layoutPanel)
            {
                layoutPanel.LayoutMode = (LayoutMode) e.NewValue;
            }
        }

        private static void LayoutOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LayoutPanel layoutPanel)
            {
                layoutPanel.LayoutOrientation = (LayoutOrientation) e.NewValue;
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var children = Children.OfType<UIElement>().ToList();
            return LayoutOrientation == LayoutOrientation.Vertical
                ? Layout.ArrangeVertical(finalSize, children)
                : Layout.ArrangeHorizontal(finalSize, children);
        }
    }
}