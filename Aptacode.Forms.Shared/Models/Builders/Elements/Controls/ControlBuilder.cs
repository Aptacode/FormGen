using System;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Controls
{
    public abstract class ControlBuilder<TElement, TBuilder> where TElement : ControlElement
        where TBuilder : ControlBuilder<TElement, TBuilder>
    {
        protected Guid Id { get; set; } = Guid.NewGuid();
        protected string Name { get; set; } = string.Empty;
        public ElementLabel Label { get; set; }
        public ControlElement.VerticalAlignment Alignment { get; set; }

        public TBuilder SetLabel(ElementLabel label)
        {
            Label = label;
            return this as TBuilder;
        }

        public TBuilder SetAlignment(ControlElement.VerticalAlignment alignment)
        {
            Alignment = alignment;
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
            Alignment = ControlElement.VerticalAlignment.Center;
        }

        public TBuilder FromTemplate(ControlElement element)
        {
            Id = element.Id;
            Name = element.Name;
            Label = element.Label;
            Alignment = element.Alignment;
            return this as TBuilder;
        }
    }
}