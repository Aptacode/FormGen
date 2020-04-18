using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;

namespace Aptacode.Forms.Elements.Fields
{
    public class CheckBoxField : FormField
    {
        private readonly IEnumerable<ValidationRule<CheckBoxField>> _rules;

        public CheckBoxField()
        {
        }

        public CheckBoxField(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<CheckBoxField>> rules, string content, bool defaultIsChecked) : base(
            nameof(ComboBoxField), name,
            labelPosition, label, rules)
        {
            _rules = rules;
            Content = content;
            DefaultIsChecked = defaultIsChecked;
            IsChecked = defaultIsChecked;
        }

        public bool DefaultIsChecked { get; set; }
        public string Content { get; set; }

        public bool IsChecked { get; set; }

        public override bool IsValid()
        {
            return ValidationRules.All(r => r is ValidationRule<CheckBoxField> rule && rule.Passed(this));
        }

        public override IEnumerable<string> GetValidationMessages()
        {
            return _rules.Select(rule => rule.GetMessage(this));
        }

        public override FieldResult GetResult()
        {
            return new CheckBoxFieldResult(this, IsChecked);
        }
    }
}