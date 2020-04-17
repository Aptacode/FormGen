using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Fields.Inputs
{
    public class ComboBoxBaseField : BaseFieldInput
    {
        public ComboBoxBaseField()
        {

        }

        public ComboBoxBaseField(IEnumerable<ValidationRule<ComboBoxBaseField>> rules) : base(nameof(ComboBoxBaseField), rules)
        {

        }

        public override bool IsValid() => ValidationRules.All(r => r is ValidationRule<ComboBoxBaseField> rule && rule.Passed(this));

    }
}