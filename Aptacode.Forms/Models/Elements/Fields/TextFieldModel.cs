using System.Collections.Generic;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Fields
{
    public class TextFieldModel : FormFieldModel
    {
        internal TextFieldModel() { }

        public TextFieldModel(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<ITextFieldViewModel>> rules) : this(name, labelPosition, label, rules,
            string.Empty) { }

        public TextFieldModel(string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule<ITextFieldViewModel>> rules, string defaultContent) : base(
            nameof(TextFieldModel), name,
            labelPosition, label)
        {
            DefaultContent = defaultContent;
            Rules = rules;
        }

        #region Properties

        public string DefaultContent { get; internal set; }

        [JsonConverter(typeof(SingleOrArrayConverter<ValidationRule<ITextFieldViewModel>>))]
        public IEnumerable<ValidationRule<ITextFieldViewModel>> Rules { get; internal set; }

        #endregion
    }
}