using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Fields.ValidationRules;
using Aptacode.Forms.Results;

namespace Aptacode.Forms.Fields.Inputs
{
    public class ComboBoxField : FormField
    {
        private readonly IEnumerable<ValidationRule<ComboBoxField>> _rules;

        public ComboBoxField()
        {
        }

        public ComboBoxField(string name, FieldLabelPosition labelPosition, string label, IEnumerable<ValidationRule<ComboBoxField>> rules, IEnumerable<string> items) : base(nameof(ComboBoxField),name,labelPosition,label, rules)
        {
            Items = items;
        }

        public string SelectedItem { get; set; }

        public IEnumerable<string> Items { get; set; }


        public override bool IsValid()
        {
            return ValidationRules.All(r => r is ValidationRule<ComboBoxField> rule && rule.Passed(this));
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