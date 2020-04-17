using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Fields.Inputs
{
    public class TextField : BaseFieldInput
    {
        private readonly IEnumerable<ValidationRule<TextField>> _rules;

        public TextField()
        {
        }

        public TextField(IEnumerable<ValidationRule<TextField>> rules) : base(nameof(TextField), rules)
        {
            _rules = rules;
        }

        public string Content { get; set; }

        public override bool IsValid()
        {
            return _rules.All(rule => rule.Passed(this));
        }

        public override IEnumerable<string> GetValidationMessages()
        {
            return _rules.Select(rule => rule.GetMessage(this));
        }
    }
}