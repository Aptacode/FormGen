using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Fields.Inputs
{
    public class ComboBoxField : BaseFieldInput
    {
        private readonly IEnumerable<ValidationRule<ComboBoxField>> _rules;

        public ComboBoxField()
        {
        }

        public ComboBoxField(IEnumerable<ValidationRule<ComboBoxField>> rules) : base(nameof(ComboBoxField), rules)
        {
        }

        public override bool IsValid()
        {
            return ValidationRules.All(r => r is ValidationRule<ComboBoxField> rule && rule.Passed(this));
        }

        public override IEnumerable<string> GetValidationMessages()
        {
            return _rules.Select(rule => rule.GetMessage(this));
        }
    }
}