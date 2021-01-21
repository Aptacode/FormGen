using System;
using System.Collections.Generic;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ValidationRules;

namespace Aptacode.Forms.Shared.Builders.Elements.Controls.Fields
{
    public class ListEditElementBuilder : ControlBuilder<ListEditElement, ListEditElementBuilder>
    {
        private List<FormElement> Values { get; set; } = new();
        private Func<FormElement> _createItem { get; set; } = () => new TextElement();

        public List<ValidationRule<IListEditElementViewModel>> Rules { get; set; } =
            new();

        public ListEditElementBuilder SetItemType(Func<FormElement> createItem)
        {
            _createItem = createItem;
            return this;
        }

        public ListEditElementBuilder AddRules(IEnumerable<ValidationRule<IListEditElementViewModel>> rules)
        {
            Rules.AddRange(rules);
            return this;
        }

        public ListEditElementBuilder AddRules(ValidationRule<IListEditElementViewModel> rule,
            params ValidationRule<IListEditElementViewModel>[] rules)
        {
            Rules.Add(rule);
            Rules.AddRange(rules);
            return this;
        }

        public ListEditElementBuilder AddValues(IEnumerable<FormElement> values)
        {
            Values.AddRange(values);
            return this;
        }

        public ListEditElementBuilder AddValues(FormElement value, params FormElement[] values)
        {
            Values.Add(value);
            Values.AddRange(values);
            return this;
        }

        public override ListEditElement Build()
        {
            var newElement = new ListEditElement
            {
                Id = Id,
                Name = Name,
                Label = Label,
                HorizontalAlignment = HorizontalAlignment,
                VerticalAlignment = VerticalAlignment,
                Values = Values,
                CreateItem = _createItem,
                Rules = Rules
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            Values = new List<FormElement>();
            Rules = new List<ValidationRule<IListEditElementViewModel>>();
            _createItem = () => new TextElement();
            base.Reset();
        }
    }
}