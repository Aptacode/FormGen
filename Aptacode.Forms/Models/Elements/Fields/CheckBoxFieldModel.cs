using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Fields
{
    [JsonConverter(typeof(SingleOrArrayConverter<ValidationRule<ICheckBoxFieldViewModel>>))]
    public class CheckBoxFieldModel : FormFieldModel<ICheckBoxFieldViewModel>
    {
        internal CheckBoxFieldModel() { }

        public CheckBoxFieldModel(string name, ElementLabel label, string content, bool defaultIsChecked,
            IEnumerable<ValidationRule<ICheckBoxFieldViewModel>> rules) : base(nameof(ComboBoxFieldModel), name, label,
            rules)
        {
            Content = content;
            DefaultIsChecked = defaultIsChecked;
        }

        public CheckBoxFieldModel(string name, ElementLabel label, string content, bool defaultIsChecked,
            params ValidationRule<ICheckBoxFieldViewModel>[] rules) : this(name, label, content, defaultIsChecked,
            rules?.ToList()) { }

        #region Properties

        public bool DefaultIsChecked { get; internal set; }
        public string Content { get; internal set; }

        #endregion
    }
}