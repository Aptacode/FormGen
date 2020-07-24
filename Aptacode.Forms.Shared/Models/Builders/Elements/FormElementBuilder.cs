using System;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.Models.Builders.Elements
{
    public abstract class FormElementBuilder<TElement, TBuilder>
        where TElement : FormElement
        where TBuilder : FormElementBuilder<TElement, TBuilder>
    {
        protected Guid Id { get; set; } = Guid.NewGuid();
        protected string Name { get; set; } = string.Empty;
        protected HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Stretch;
        protected VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Stretch;

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

        public abstract TElement Build();

        public virtual void Reset()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        public virtual TBuilder FromTemplate(FormElement element)
        {
            Id = element.Id;
            Name = element.Name;
            VerticalAlignment = VerticalAlignment;
            HorizontalAlignment = HorizontalAlignment; 
            return this as TBuilder;
        }
    }
}