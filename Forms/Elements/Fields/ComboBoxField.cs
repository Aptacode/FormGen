using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;

namespace Aptacode.Forms.Elements.Fields
{
    public class ComboBoxField : FormField
    {
        private readonly IEnumerable<ValidationRule<ComboBoxField>> _rules;

        public ComboBoxField()
        {
        }

        public ComboBoxField(string name, FieldLabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<ComboBoxField>> rules, IEnumerable<string> items, string defaultSelectedItem) :
            base(nameof(ComboBoxField), name, labelPosition, label, rules)
        {
            _rules = rules;
            DefaultSelectedItem = defaultSelectedItem;
            SelectedItem = defaultSelectedItem;
            Items = items;
        }

        public string DefaultSelectedItem { get; set; }
        public string SelectedItem { get; set; }
        public IEnumerable<string> Items { get; set; }

        public override bool IsValid()
        {
            return _rules.All(rule => rule.Passed(this));
        }

        public override IEnumerable<string> GetValidationMessages()
        {
            return _rules.Select(rule => rule.GetMessage(this));
        }

        public override FieldResult GetResult()
        {
            return new ComboBoxFieldResult(this, Items, SelectedItem);
        }
    }
}