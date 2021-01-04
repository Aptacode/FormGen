using System.Collections.Generic;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ValidationRules;

namespace Aptacode.Forms.Shared.Builders.Elements.Controls.Fields
{
    public class SelectElementBuilder : ControlBuilder<SelectElement, SelectElementBuilder>
    {
        public string DefaultValue { get; set; } = string.Empty;
        public List<string> Values { get; set; } = new();

        public List<ValidationRule<ISelectElementViewModel>> Rules { get; set; } =
            new();


        public SelectElementBuilder SetDefaultValue(string defaultValue)
        {
            DefaultValue = defaultValue;
            return this;
        }

        public SelectElementBuilder AddRules(IEnumerable<ValidationRule<ISelectElementViewModel>> rules)
        {
            Rules.AddRange(rules);
            return this;
        }

        public SelectElementBuilder AddRules(ValidationRule<ISelectElementViewModel> rule,
            params ValidationRule<ISelectElementViewModel>[] rules)
        {
            Rules.Add(rule);
            Rules.AddRange(rules);
            return this;
        }

        public SelectElementBuilder AddValues(IEnumerable<string> values)
        {
            Values.AddRange(values);
            return this;
        }

        public SelectElementBuilder AddValues(string value, params string[] values)
        {
            Values.Add(value);
            Values.AddRange(values);
            return this;
        }

        public override SelectElement Build()
        {
            var newElement = new SelectElement
            {
                Id = Id,
                Name = Name,
                Label = Label,
                HorizontalAlignment = HorizontalAlignment,
                VerticalAlignment = VerticalAlignment,
                DefaultValue = DefaultValue,
                Values = Values,
                Rules = Rules
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            DefaultValue = string.Empty;
            Values = new List<string>();
            Rules = new List<ValidationRule<ISelectElementViewModel>>();

            base.Reset();
        }
    }
}