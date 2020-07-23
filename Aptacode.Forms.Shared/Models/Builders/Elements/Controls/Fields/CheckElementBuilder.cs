using System.Collections.Generic;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.Models.Builders.Elements.Controls.Fields
{
    public class CheckElementBuilder : ControlBuilder<CheckElement, CheckElementBuilder>
    {
        private string Content { get; set; } = string.Empty;
        public bool DefaultValue { get; set; }

        public List<ValidationRule<ICheckElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<ICheckElementViewModel>>();

        public CheckElementBuilder SetContent(string content)
        {
            Content = content;
            return this;
        }

        public CheckElementBuilder SetDefaultValue(bool defaultValue)
        {
            DefaultValue = defaultValue;
            return this;
        }

        public CheckElementBuilder AddRules(IEnumerable<ValidationRule<ICheckElementViewModel>> rules)
        {
            Rules.AddRange(rules);
            return this;
        }

        public CheckElementBuilder AddRules(ValidationRule<ICheckElementViewModel> rule,
            params ValidationRule<ICheckElementViewModel>[] rules)
        {
            Rules.Add(rule);
            Rules.AddRange(rules);
            return this;
        }

        public override CheckElement Build()
        {
            var newElement = new CheckElement
            {
                Id = Id,
                Name = Name,
                Content = Content,
                Label = Label,
                Alignment = Alignment,
                DefaultValue = DefaultValue,
                Rules = Rules
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            Content = string.Empty;
            DefaultValue = false;
            Rules = new List<ValidationRule<ICheckElementViewModel>>();

            base.Reset();
        }
    }
}