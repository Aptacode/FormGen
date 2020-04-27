using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;

namespace Aptacode.Forms.Elements.Fields
{
    public class ComboBoxField : FormField
    {
        internal ComboBoxField()
        {
        }

        public ComboBoxField(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<ComboBoxField>> rules, IEnumerable<string> items) : this(name, labelPosition,
            label, rules, items, string.Empty)
        {
        }

        public ComboBoxField(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<ComboBoxField>> rules, IEnumerable<string> items, string defaultSelectedItem) :
            base(nameof(ComboBoxField), name, labelPosition, label, rules)
        {
            DefaultSelectedItem = defaultSelectedItem;
            SelectedItem = defaultSelectedItem;
            Items = items;
        }

        private IEnumerable<ValidationRule<ComboBoxField>> Rules =>
            ValidationRules.Select(r => r as ValidationRule<ComboBoxField>);

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
            return new ComboBoxFieldResult(this, Items, SelectedItem);
        }

        #region Properties

        public string DefaultSelectedItem { get; set; }
        public IEnumerable<string> Items { get; set; }

        private string _selectedItem;

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                TriggerEvent(new ComboBoxFieldChangedEventArgs(this, _selectedItem));
            }
        }

        #endregion
    }
}