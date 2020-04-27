using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;

namespace Aptacode.Forms.Elements.Fields
{
    public class TextField : FormField
    {
        internal TextField()
        {
            Rules = new List<ValidationRule<TextField>>();
        }

        public TextField(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<TextField>> rules) : base(nameof(TextField), name, labelPosition, label)
        {
            Content = string.Empty;
            Rules = rules;
        }
        

        public override bool IsValid()
        {
            return Rules.All(rule => rule.Passed(this));
        }

        public override IEnumerable<string> GetValidationMessages()
        {
            return Rules.Select(rule => rule.GetMessage(this));
        }

        public override FieldResult GetResult()
        {
            return new TextFieldResult(this, Content);
        }

        #region Properties

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                var oldValue = _content;
                _content = value;
                TriggerEvent(new TextFieldChangedEventArgs(this, oldValue, value));
            }
        }

        public IEnumerable<ValidationRule<TextField>> Rules { get; set; }

        #endregion
    }
}