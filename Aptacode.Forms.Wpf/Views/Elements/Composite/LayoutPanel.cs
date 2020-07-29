using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Wpf.Views.Elements.Composite.LayoutStrategy;

namespace Aptacode.Forms.Wpf.Views.Elements.Composite
{
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

        public LayoutStrategy.LayoutStrategy Layout { get; set; } = new StretchLayoutStrategy();

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