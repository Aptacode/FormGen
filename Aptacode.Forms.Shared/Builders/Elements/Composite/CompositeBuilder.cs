using System.Collections.Generic;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.Builders.Elements.Composite
{
    public abstract class
        CompositeBuilder<TCompositeElement, TBuilder> : FormElementBuilder<TCompositeElement, TBuilder>
        where TCompositeElement : CompositeElement
        where TBuilder : CompositeBuilder<TCompositeElement, TBuilder>
    {
        protected List<FormElement> Children { get; set; } = new List<FormElement>();
        protected LayoutMode LayoutMode { get; set; } = LayoutMode.Shrink;
        protected LayoutOrientation LayoutOrientation { get; set; } = LayoutOrientation.Vertical;

        public TBuilder SetOrientation(LayoutOrientation orientation)
        {
            LayoutOrientation = orientation;
            return this as TBuilder;
        }

        public TBuilder SetMode(LayoutMode mode)
        {
            LayoutMode = mode;
            return this as TBuilder;
        }

        public TBuilder AddChildren(IEnumerable<FormElement> children)
        {
            Children.AddRange(children);
            return this as TBuilder;
        }

        public TBuilder AddChildren(FormElement child, params FormElement[] children)
        {
            Children.Add(child);
            Children.AddRange(children);
            return this as TBuilder;
        }


        public override void Reset()
        {
            Children = new List<FormElement>();
            LayoutMode = LayoutMode.Shrink;
            LayoutOrientation = LayoutOrientation.Vertical;
            base.Reset();
        }

        public TBuilder FromTemplate(CompositeElement element)
        {
            Children = new List<FormElement>(element.Children);
            return base.FromTemplate(element);
        }
    }
}