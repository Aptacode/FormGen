using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aptacode.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Fields.Inputs
{
    public class ComboBoxBaseField : BaseFieldInput
    {
        private readonly IEnumerable<ValidationRule<ComboBoxBaseField>> _rules;
        public ComboBoxBaseField()
        {

        }

        public ComboBoxBaseField(IEnumerable<ValidationRule<ComboBoxBaseField>> rules) : base(nameof(ComboBoxBaseField), rules)
        {

        }

        public override bool IsValid() => ValidationRules.All(r => r is ValidationRule<ComboBoxBaseField> rule && rule.Passed(this));
        public override string GetValidationMessage()
        {
            var validationMessageBuilder = new StringBuilder();
            foreach (var validationRule in _rules)
            {
                var validationMessage = validationRule.GetMessage(this);
                if (string.IsNullOrEmpty(validationMessage))
                    continue;
                validationMessageBuilder.AppendLine(validationMessage);
            }

            return validationMessageBuilder.ToString();
        }
    }
}