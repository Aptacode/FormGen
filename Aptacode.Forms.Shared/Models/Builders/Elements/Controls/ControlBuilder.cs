using System;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Controls
{
    public abstract class ControlBuilder<TElement, TBuilder> where TElement : ControlElement
        where TBuilder : ControlBuilder<TElement, TBuilder>
    {
        protected Guid Id { get; set; } = Guid.NewGuid();
        protected string Name { get; set; } = string.Empty;
        public ElementLabel Label { get; set; }
        protected HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Stretch;
        protected VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Stretch;
        public TBuilder SetLabel(ElementLabel label)
        {
            Label = label;
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
            Label = ElementLabel.None;
            VerticalAlignment = VerticalAlignment.Stretch;
            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        public TBuilder FromTemplate(ControlElement element)
        {
            Id = element.Id;
            Name = element.Name;
            Label = element.Label;
            VerticalAlignment = VerticalAlignment;
            HorizontalAlignment = HorizontalAlignment; 
            return this as TBuilder;
        }
    }
}