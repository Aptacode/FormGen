using System.Collections.Generic;
using System.Windows;

namespace Aptacode.Forms.Wpf.Views.Elements.Composite {
    public abstract class LayoutStrategy
    {
        public abstract Size ArrangeHorizontal(Size finalSize, IReadOnlyList<UIElement> children);
        public abstract Size ArrangeVertical(Size finalSize, IReadOnlyList<UIElement> children);
    }
}