using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;

namespace Aptacode.Forms.Elements.Fields
{
    public class CheckBoxField : FormField
    {
        internal CheckBoxField()
        {
            Rules = new List<ValidationRule<CheckBoxField>>();
        }

        public CheckBoxField(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<CheckBoxField>> rules, string content, bool defaultIsChecked) : base(
            nameof(CheckBoxField), name,
            labelPosition, label)
        {
            Content = content;
            DefaultIsChecked = defaultIsChecked;
            IsChecked = defaultIsChecked;
            Rules = rules;
        }

        public override bool IsValid()
        {
            return Rules.All(r => r.Passed(this));
        }

        public override IEnumerable<string> GetValidationMessages()
        {
            return Rules.Select(rule => rule.GetMessage(this));
        }

        public override FieldResult GetResult()
        {
            return new CheckBoxFieldResult(this, IsChecked);
        }

        #region Properties

        public bool DefaultIsChecked { get; set; }
        public string Content { get; set; }

        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                TriggerEvent(new CheckBoxFieldChangedEventArgs(this, _isChecked));
            }
        }
        public IEnumerable<ValidationRule<CheckBoxField>> Rules { get; set; }

        #endregion
    }
}