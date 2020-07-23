using System.Linq;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels
{
    public static class FormViewModelExtensions
    {
        #region Layout

        public static CompositeElement SetRoot(this Form form, CompositeElement element)
        {
            form.RootElement = element;
            return element;
        }

        public static CompositeElement AddChildren(this CompositeElement parent, params FormElement[] children)
        {
            var allChildren = parent.Children.ToList();
            allChildren.AddRange(children.ToList());
            parent.Children = allChildren;

            return parent;
        }

        public static CompositeElement Add(this CompositeElement parent, CompositeElement child)
        {
            var allChildren = parent.Children.ToList();
            allChildren.Add(child);
            parent.Children = allChildren;
            return child;
        }

        public static CompositeElement Add(this CompositeElement parent, ControlElement child)
        {
            var allChildren = parent.Children.ToList();
            allChildren.Add(child);
            parent.Children = allChildren;
            return parent;
        }

        #endregion
    }
}