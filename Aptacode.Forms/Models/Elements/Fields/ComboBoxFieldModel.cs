using System.Collections.Generic;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Fields
{
    public class ComboBoxFieldModel : FormFieldModel
    {
        internal ComboBoxFieldModel() { }

        public ComboBoxFieldModel(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<IComboBoxFieldViewModel>> rules, IEnumerable<string> items) : this(name,
            labelPosition,
            label, rules, items, string.Empty) { }

        public ComboBoxFieldModel(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<IComboBoxFieldViewModel>> rules, IEnumerable<string> items,
            string defaultSelectedItem) :
            base(nameof(ComboBoxFieldModel), name, labelPosition, label)
        {
            DefaultSelectedItem = defaultSelectedItem;
            Items = items;
            Rules = rules;
        }

        #region Properties

        public string DefaultSelectedItem { get; internal set; }
        public IEnumerable<string> Items { get; internal set; }


        [JsonConverter(typeof(SingleOrArrayConverter<ValidationRule<IComboBoxFieldViewModel>>))]
        public IEnumerable<ValidationRule<IComboBoxFieldViewModel>> Rules { get; }

        #endregion
    }
}