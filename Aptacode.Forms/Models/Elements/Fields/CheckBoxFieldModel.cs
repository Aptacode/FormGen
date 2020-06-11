using System.Collections.Generic;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Fields
{
    public class CheckBoxFieldModel : FormFieldModel
    {
        internal CheckBoxFieldModel() { }

        public CheckBoxFieldModel(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<ICheckBoxFieldViewModel>> rules, string content, bool defaultIsChecked) : base(
            nameof(CheckBoxFieldModel), name,
            labelPosition, label)
        {
            Content = content;
            DefaultIsChecked = defaultIsChecked;
            Rules = rules;
        }

        #region Properties

        public bool DefaultIsChecked { get; internal set; }
        public string Content { get; internal set; }

        [JsonConverter(typeof(SingleOrArrayConverter<ValidationRule<ICheckBoxFieldViewModel>>))]
        public IEnumerable<ValidationRule<ICheckBoxFieldViewModel>> Rules { get; internal set; }

        #endregion
    }
}