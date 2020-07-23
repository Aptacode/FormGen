using System;
using System.Collections.Generic;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public abstract class LayoutBuilder<TCompositeElement, TBuilder> where TCompositeElement : CompositeElement
        where TBuilder : LayoutBuilder<TCompositeElement, TBuilder>
    {
        protected Guid Id { get; set; } = Guid.NewGuid();
        protected string Name { get; set; } = string.Empty;
        protected HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Stretch;
        protected VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Stretch;

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

        public TBuilder SetName(string name)
        {
            Name = name;
            return this as TBuilder;
        }
        public TBuilder SetVerticalAlignment(VerticalAlignment verticalAlignment)
        {
            VerticalAlignment = verticalAlignment;
            return this as TBuilder;
        }
        public TBuilder SetHorizontalAlignment(HorizontalAlignment horizontalAlignment)
        {
            HorizontalAlignment = horizontalAlignment;
            return this as TBuilder;
        }

        public TBuilder SetId(Guid id)
        {
            Id = id;
            return this as TBuilder;
        }

        public abstract TCompositeElement Build();

        public virtual void Reset()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Children = new List<FormElement>();
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        public TBuilder FromTemplate(CompositeElement element)
        {
            Id = element.Id;
            Name = element.Name;
            Children = new List<FormElement>(element.Children);
            VerticalAlignment = VerticalAlignment;
            HorizontalAlignment = HorizontalAlignment;
            return this as TBuilder;
        }
    }
}