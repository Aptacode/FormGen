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

        public ComboBoxField(string name, FieldLabelPosition labelPosition, string label, IEnumerable<ValidationRule<ComboBoxField>> rules, bool defaultIsChecked) : base(nameof(ComboBoxField),name,labelPosition,label, rules)
        {
            DefaultIsChecked = defaultIsChecked;
            IsChecked = defaultIsChecked;
        }

        public bool DefaultIsChecked { get; set; }

        public bool IsChecked { get; set; }

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
            return new ComboBoxFieldResult(this, IsChecked);
        }
    }
}