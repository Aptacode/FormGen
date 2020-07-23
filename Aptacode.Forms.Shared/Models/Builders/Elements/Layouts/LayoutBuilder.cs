using System;
using System.Collections.Generic;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Layouts
{
    public abstract class LayoutBuilder<TCompositeElement, TBuilder> where TCompositeElement : CompositeElement
        where TBuilder : LayoutBuilder<TCompositeElement, TBuilder>
    {
        protected Guid Id { get; set; } = Guid.NewGuid();
        protected string Name { get; set; } = string.Empty;
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
        }

        public TBuilder FromTemplate(CompositeElement element)
        {
            Id = element.Id;
            Name = element.Name;
            Children = new List<FormElement>(element.Children);
            return this as TBuilder;
        }
    }
}