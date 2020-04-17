using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aptacode.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Fields.Inputs
{
    public class TextBaseField : BaseFieldInput
    {
        private readonly IEnumerable<ValidationRule<TextBaseField>> _rules;
        public TextBaseField()
        {

        }

        public TextBaseField(IEnumerable<ValidationRule<TextBaseField>> rules) : base(nameof(TextBaseField), rules)
        {
            _rules = rules;
        }

        public override bool IsValid() => _rules.All(rule => rule.Passed(this));
        public override IEnumerable<string> GetValidationMessages() => _rules.Select(rule => rule.GetMessage(this));
        public string Content { get; set; }
    }
}