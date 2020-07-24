using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Controls
{
    public abstract class ControlBuilder<TElement, TBuilder> : FormElementBuilder<TElement, TBuilder> 
        where TElement : ControlElement
        where TBuilder : ControlBuilder<TElement, TBuilder>
    {
        public ElementLabel Label { get; set; }
        public TBuilder SetLabel(ElementLabel label)
        {
            Label = label;
            return this as TBuilder;
        }

        public override void Reset()
        { 
            Label = ElementLabel.None;
            base.Reset();
        }

        public TBuilder FromTemplate(ControlElement element)
        {
            Label = element.Label;
            return base.FromTemplate(element);
        }
    }
}