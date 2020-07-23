using System.Collections.Generic;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Controls.Fields
{
    public class TextElementBuilder : ControlBuilder<TextElement, TextElementBuilder>
    {
        public string DefaultValue { get; set; } = string.Empty;

        public List<ValidationRule<ITextElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<ITextElementViewModel>>();


        public TextElementBuilder SetDefaultValue(string defaultValue)
        {
            DefaultValue = defaultValue;
            return this;
        }

        public TextElementBuilder AddRules(IEnumerable<ValidationRule<ITextElementViewModel>> rules)
        {
            Rules.AddRange(rules);
            return this;
        }

        public TextElementBuilder AddRules(ValidationRule<ITextElementViewModel> rule,
            params ValidationRule<ITextElementViewModel>[] rules)
        {
            Rules.Add(rule);
            Rules.AddRange(rules);
            return this;
        }


        public override TextElement Build()
        {
            var newElement = new TextElement
            {
                Id = Id,
                Name = Name,
                Label = Label,
                HorizontalAlignment = HorizontalAlignment,
                VerticalAlignment = VerticalAlignment,
                DefaultValue = DefaultValue,
                Rules = Rules
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            DefaultValue = string.Empty;
            Rules = new List<ValidationRule<ITextElementViewModel>>();

            base.Reset();
        }
    }
}