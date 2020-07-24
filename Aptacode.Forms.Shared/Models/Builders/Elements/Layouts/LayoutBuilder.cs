using System.Collections.Generic;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public abstract class LayoutBuilder<TCompositeElement, TBuilder> : FormElementBuilder<TCompositeElement, TBuilder>
        where TCompositeElement : CompositeElement
        where TBuilder : LayoutBuilder<TCompositeElement, TBuilder>
    {
        protected List<FormElement> Children { get; set; } = new List<FormElement>();

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
            base.Reset();
        }

        public TBuilder FromTemplate(CompositeElement element)
        {
            Children = new List<FormElement>(element.Children);
            return base.FromTemplate(element);
        }
    }
}