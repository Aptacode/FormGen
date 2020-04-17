using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Fields.ValidationRules;
using Aptacode.Forms.Results;

namespace Aptacode.Forms.Fields.Inputs
{
    public class TextField : FormField
    {
        private readonly IEnumerable<ValidationRule<TextField>> _rules;

        public TextField()
        {
        }

        public TextField(string name, FieldLabelPosition labelPosition, string label, IEnumerable<ValidationRule<TextField>> rules) : base(nameof(TextField), name, labelPosition, label, rules)
        {
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

        public override FieldResult GetResult()
        {
            return new TextFieldResult(this, Content);
        }
    }
}