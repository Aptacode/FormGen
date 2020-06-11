using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Fields
{
    [JsonConverter(typeof(SingleOrArrayConverter<ValidationRule<IComboBoxFieldViewModel>>))]
    public class ComboBoxFieldModel : FormFieldModel<IComboBoxFieldViewModel>
    {
        internal ComboBoxFieldModel() { }

        public ComboBoxFieldModel(string name, ElementLabel label, IEnumerable<string> items,
            string defaultSelectedItem, IEnumerable<ValidationRule<IComboBoxFieldViewModel>> rules) : base(
            nameof(ComboBoxFieldModel), name, label, rules)
        {
            DefaultSelectedItem = defaultSelectedItem;
            Items = items;
        }

        public ComboBoxFieldModel(string name, ElementLabel label, IEnumerable<string> items,
            string defaultSelectedItem, params ValidationRule<IComboBoxFieldViewModel>[] rules) : this(name, label,
            items, defaultSelectedItem, rules?.ToList()) { }

        #region Properties

        public string DefaultSelectedItem { get; internal set; }
        public IEnumerable<string> Items { get; internal set; }

        #endregion
    }
}